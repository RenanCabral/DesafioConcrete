using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.Tests
{   
    public class TesteBase
    {
        public Domain.Usuario CriarUsuario(string email, string senha)
        {
            return new Domain.Usuario("Test", email, senha,Guid.NewGuid().ToString());
        }
    }
}
