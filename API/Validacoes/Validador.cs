using Infra.Interfaces;
using API.Models;
using API.Util;
using System.Collections.Generic;

namespace API.Validacoes
{
    public class Validador
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public Validador(IUsuarioRepositorio usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
        }

        public MensagemErro Validar(Usuario usuario, List<IValidacao> validacoes)
        {
            foreach (var validacao in validacoes)
            {
                var mensagemErro = validacao.Validar(_usuarioRepositorio, usuario);

                if (mensagemErro != null)
                    return mensagemErro;
            }

            return null;
        }
    }
}