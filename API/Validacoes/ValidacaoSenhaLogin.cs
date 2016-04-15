using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;
using API.Util;
using Infra.Interfaces;

namespace API.Validacoes
{
    public class ValidacaoSenhaLogin : IValidacao
    {
        public MensagemErro Validar(IUsuarioRepositorio usuarioRepositorio, Usuario usuario)
        {
            MensagemErro mensagemErro = null;

            var usuarioDomain = usuarioRepositorio.RetornarUsuario(u => u.Email == usuario.Email && u.Senha == usuario.Senha);

            if (usuarioDomain == null)
            {
                mensagemErro = new MensagemErro(System.Net.HttpStatusCode.Unauthorized, "Email e/ou senha inválidos.");
                return mensagemErro;
            }

            return null;
        }
    }
}