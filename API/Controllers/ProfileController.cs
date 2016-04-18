using API.Models;
using API.Validacoes;
using Infra.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProfileController : ApiController
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public ProfileController(IUsuarioRepositorio usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            if (Request.Headers.Authorization == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var token = Request.Headers.Authorization.Parameter;

            if (string.IsNullOrEmpty(token))
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var validacoes = new List<IValidacao>();
            validacoes.Add(new ValidacaoToken());

            var usuario = new Usuario(null, null, token);
            usuario.Id = id;

            var mensagemErro = new Validador(_usuarioRepositorio).Validar(usuario, validacoes);

            if (mensagemErro != null)
                return Request.CreateResponse(mensagemErro.CodigoErro, mensagemErro);

            return Request.CreateResponse(HttpStatusCode.OK, Usuario.CriarUsuarioModel(_usuarioRepositorio.RetornarUsuario(id)));
        }

    }
}
