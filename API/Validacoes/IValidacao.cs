using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Util;
using Infra.Interfaces;
using API.Models;

namespace API.Validacoes
{
    public interface IValidacao
    {
        MensagemErro Validar(IUsuarioRepositorio usuarioRepositorio, Usuario usuario);
    }
}
