using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infra.Interfaces;

namespace Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private List<Usuario> _usuarios;

        private List<Usuario> Usuarios
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new List<Usuario>();
                    _usuarios.Add(new Usuario(1,"Renan", "renan@mail.com", "XXXX"));
                    _usuarios.Add(new Usuario(2,"Sabrina", "sabrina@mail.com", "YYYY"));
                    _usuarios.Add(new Usuario(3,"Letícia", "lele@mail.com", "ZZZZZ"));
                    _usuarios.Add(new Usuario(4,"Sandoval", "sandoval@mail.com", "WWWW"));
                    _usuarios.Add(new Usuario(5,"Gerônimo", "geronimo@mail.com", "KKKKK"));
                }

                return _usuarios;
            }
        }

        public List<Usuario> RetornarUsuarios()
        {
            return Usuarios;
        }

        public Usuario RetornarUsuario(Func<Usuario,bool> where)
        {
           return Usuarios.FirstOrDefault(where);
        }

        public Usuario RetornarUsuarioPorEmail(string email)
        {
            return Usuarios.FirstOrDefault(u=> u.Email == email);
        }

        public void Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
