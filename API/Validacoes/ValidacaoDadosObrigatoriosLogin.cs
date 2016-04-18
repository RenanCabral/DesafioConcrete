using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;
using API.Util;
using Infra.Interfaces;

namespace API.Validacoes
{
    public class ValidacaoDadosObrigatoriosLogin : IValidacao
    {
        public MensagemErro Validar(IUsuarioRepositorio usuarioRepositorio, Usuario usuario)
        {
            if (String.IsNullOrEmpty(usuario.Email))
                return new MensagemErro(System.Net.HttpStatusCode.BadRequest, "Email é obrigatório.");

            if (String.IsNullOrEmpty(usuario.Senha))
                return new MensagemErro(System.Net.HttpStatusCode.BadRequest, "Senha é obrigatória.");

            return null;
        }
    }
}