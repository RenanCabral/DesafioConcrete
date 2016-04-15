using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;
using API.Util;
using Infra.Interfaces;

namespace API.Validacoes
{
    public class ValidacaoEmailSignup : IValidacao
    {
        public MensagemErro Validar(IUsuarioRepositorio usuarioRepositorio, Usuario usuario)
        {
            MensagemErro mensagemErro = null;

            var usuarioDomain = usuarioRepositorio.RetornarUsuarioPorEmail(usuario.Email);

            if (usuarioDomain != null)
            {
                mensagemErro = new MensagemErro(System.Net.HttpStatusCode.Unauthorized, "Email já cadastrado.");
                return mensagemErro;
            }

            return null;
        }
    }
}