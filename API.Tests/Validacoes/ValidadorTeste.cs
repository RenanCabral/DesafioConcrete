using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Infra.Interfaces;
using Domain;
using API.Validacoes;
using System.Net;

namespace API.Tests.Validacoes
{
    [TestClass]
    public class ValidadorTeste : TesteBase
    {
        Mock<IUsuarioRepositorio> usuarioRepositorioMock = null;

        [TestInitialize]
        public void SetUp()
        {
            usuarioRepositorioMock = new Mock<IUsuarioRepositorio>();
        }

        #region Validação Signup

        [TestMethod]
        public void Validar_Email_Signup_Esperando_MensagemErro_Email_Existente()
        {
            //arrange
            usuarioRepositorioMock.Setup(x => x.RetornarUsuarioPorEmail("renan@mail.com")).Returns(base.CriarUsuario("renan@mail.com", "XXX"));

            var validacoes = new List<IValidacao>();
            validacoes.Add(new ValidacaoEmailSignup());

            var validador = new Validador(usuarioRepositorioMock.Object);
            var usuarioModel = new API.Models.Usuario("Renan", "renan@mail.com");

            //act
            var mensagemErro = validador.Validar(usuarioModel, validacoes);

            //assert
            Assert.IsNotNull(mensagemErro);
            Assert.AreEqual("Email já cadastrado.", mensagemErro.Mensagem);
            Assert.AreEqual(HttpStatusCode.Unauthorized, mensagemErro.CodigoErro);
        }

        [TestMethod]
        public void Validar_Email_Signup_Esperando_MensagemErro_Nula()
        {
            //arrange
            Usuario usuario = null;
            usuarioRepositorioMock.Setup(x => x.RetornarUsuarioPorEmail("renan@mail.com")).Returns(usuario);

            var validacoes = new List<IValidacao>();
            validacoes.Add(new ValidacaoEmailSignup());

            var validador = new Validador(usuarioRepositorioMock.Object);
            var usuarioModel = new API.Models.Usuario("Renan", "renan@mail.com");

            //act
            var mensagemErro = validador.Validar(usuarioModel, validacoes);

            //assert
            Assert.IsNull(mensagemErro);
        }

        #endregion

        #region Validação Login 

        [TestMethod]
        public void Validar_Email_Login_Esperando_Email_Invalido()
        {
            //arrange
            Usuario usuario = null;
            usuarioRepositorioMock.Setup(x => x.RetornarUsuarioPorEmail("renan@mail.com")).Returns(usuario);

            var validacoes = new List<IValidacao>();
            validacoes.Add(new ValidacaoEmailLogin());

            var validador = new Validador(usuarioRepositorioMock.Object);
            var usuarioModel = new API.Models.Usuario("Renan", "renan@mail.com");

            //act
            var mensagemErro = validador.Validar(usuarioModel, validacoes);

            //assert
            Assert.IsNotNull(mensagemErro);
            Assert.AreEqual("Email e/ou senha inválidos.", mensagemErro.Mensagem);
            Assert.AreEqual(HttpStatusCode.Unauthorized, mensagemErro.CodigoErro); 
        }

        #endregion

        #region Validação Profile 
        #endregion
    }
}
