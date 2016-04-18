using System;
using API.Models;
using API.Util;
using Infra.Interfaces;
using System.Configuration;
using System.Net;

namespace API.Validacoes
{
    public class ValidacaoToken : IValidacao
    {
        public MensagemErro Validar(IUsuarioRepositorio usuarioRepositorio, Usuario usuario)
        {
            var tokenExistente = (usuarioRepositorio.RetornarUsuario(u => u.Token == usuario.Token) != null);

            if (!tokenExistente)
                return new MensagemErro(HttpStatusCode.Unauthorized, "Não autorizado");

            var usuarioDomain = usuarioRepositorio.RetornarUsuario(usuario.Id);

            if (usuarioDomain.Token != usuario.Token)
                return new MensagemErro(HttpStatusCode.Unauthorized, "Não autorizado");


            if (usuarioDomain.Token == usuario.Token)
            {
                var tempoLimiteSessao = Convert.ToInt32(ConfigurationManager.AppSettings["tempoLimiteSessao"].ToString());

                if (usuarioDomain.UltimoLogin < DateTime.Now.AddMinutes(-tempoLimiteSessao))
                    return new MensagemErro(HttpStatusCode.Unauthorized, "Sessão inválida.");
            }

            return null;
        }
    }
}