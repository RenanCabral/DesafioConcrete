using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Util;
using Infra.Interfaces;
using API.Models;

namespace API.Validacoes
{
    public class ValidacaoEmailLogin : IValidacao
    {
        public MensagemErro Validar(IUsuarioRepositorio usuarioRepositorio, Usuario usuario)
        {
            MensagemErro mensagemErro = null;

            var usuarioDomain = usuarioRepositorio.RetornarUsuario(u => u.Email == usuario.Email);

            if (usuarioDomain == null)
            {
                mensagemErro = new MensagemErro(System.Net.HttpStatusCode.Unauthorized, "Email e/ou senha inválidos.");
                return mensagemErro;
            }

            return null;
        }
    }
}