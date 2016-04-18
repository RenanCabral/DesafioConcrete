using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using Infra.Interfaces;
using API.Filtros;
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
        [ModelValidateFilter]
        public HttpResponseMessage Post(Usuario usuario)
        {
            //TODO: Factory
            var validacoes = new List<IValidacao>();

            validacoes.Add(new ValidacaoDadosObrigatoriosLogin());
            validacoes.Add(new ValidacaoEmailLogin());
            validacoes.Add(new ValidacaoSenhaLogin());

            var mensagemErro = new Validador(_usuarioRepositorio).Validar(usuario, validacoes);

            if (mensagemErro != null)
                return Request.CreateResponse(mensagemErro.CodigoErro, mensagemErro);

            var usuarioAutenticado =_usuarioRepositorio.RetornarUsuarioPorEmail(usuario.Email);
            _usuarioRepositorio.AtualizarRegistroAcessoLogin(usuarioAutenticado.Id);

            var response = Request.CreateResponse(HttpStatusCode.OK, Usuario.CriarUsuarioModel(usuarioAutenticado));

            response.Headers.Add("Token", usuarioAutenticado.Token);

            return response;
        }
    }
}
