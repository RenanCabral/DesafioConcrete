using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> RetornarUsuarios();
        void Adicionar(Usuario usuario);
        void AtualizarRegistroAcessoLogin(int id);
        Usuario RetornarUsuario(int id);
        Usuario RetornarUsuario(Func<Usuario, bool> where);
        Usuario RetornarUsuarioPorEmail(string email);
    }
}
