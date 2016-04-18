using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using Infra.Interfaces;
using API.Validacoes;
using API.Filtros;

namespace API.Controllers
{
    public class SignUpController : ApiController
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public SignUpController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        [ModelValidateFilter]
        public HttpResponseMessage Post(Usuario usuario)
        {
            var validacoes = new List<IValidacao>();

            validacoes.Add(new ValidacaoDadosObrigatoriosSignup());
            validacoes.Add(new ValidacaoEmailSignup());

            var validador = new Validador(_usuarioRepositorio);
            var mensagemErro = validador.Validar(usuario, validacoes);

            if (mensagemErro != null)
                return Request.CreateResponse(mensagemErro.CodigoErro, mensagemErro);

            _usuarioRepositorio.Adicionar(Usuario.CriarUsuarioDomain(usuario));

            var usuarioCadastrado = _usuarioRepositorio.RetornarUsuarioPorEmail(usuario.Email);

            var response = Request.CreateResponse(HttpStatusCode.OK, Usuario.CriarUsuarioModel(usuarioCadastrado));
            
            response.Headers.Add("Token", usuarioCadastrado.Token);

            return response;
        }
    }
}
