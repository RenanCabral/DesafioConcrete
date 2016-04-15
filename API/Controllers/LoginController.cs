using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using Infra.Interfaces;
using API.Util;
using API.Validacoes; 

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        public HttpResponseMessage Post(Usuario usuario)
        {
            //TODO: Factory
            var validacoes = new List<IValidacao>();
            validacoes.Add(new ValidacaoEmailLogin());
            validacoes.Add(new ValidacaoSenhaLogin());

            var mensagemErro = new Validador(_usuarioRepositorio).Validar(usuario, validacoes);

            if (mensagemErro != null)
                return Request.CreateResponse(mensagemErro.CodigoErro, mensagemErro);

            return Request.CreateResponse(HttpStatusCode.OK, Usuario.CriarUsuario(_usuarioRepositorio.RetornarUsuarioPorEmail(usuario.Email)));
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
