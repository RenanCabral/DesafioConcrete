using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;
using API.Util;
using Infra.Interfaces;

namespace API.Validacoes
{
    public class ValidacaoDadosObrigatoriosSignup : IValidacao
    {
        public MensagemErro Validar(IUsuarioRepositorio usuarioRepositorio, Usuario usuario)
        {
            if (String.IsNullOrEmpty(usuario.Nome))
                return new MensagemErro(System.Net.HttpStatusCode.BadRequest, "Nome é obrigatório.");

            var mensagemErroDadosLogin = new ValidacaoDadosObrigatoriosLogin().Validar(usuarioRepositorio, usuario);

            if (mensagemErroDadosLogin != null)
                return mensagemErroDadosLogin;

            return null;
        }
    }
}