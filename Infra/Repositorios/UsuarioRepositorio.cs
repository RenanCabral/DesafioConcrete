using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Infra.Interfaces;

namespace Infra.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static List<Usuario> _usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new List<Usuario>();
                }

                return _usuarios;
            }
        }

        public List<Usuario> RetornarUsuarios()
        {
            return Usuarios;
        }

        public Usuario RetornarUsuario(int id)
        {
            return Usuarios.FirstOrDefault(u=> u.Id == id);
        }

        public Usuario RetornarUsuario(Func<Usuario, bool> where)
        {
            return Usuarios.FirstOrDefault(where);
        }

        public Usuario RetornarUsuarioPorEmail(string email)
        {
            return Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Adicionar(Usuario usuario)
        {
            usuario.Id = (Usuarios.Count + 1);
            Usuarios.Add(usuario);
        }

        /// <summary>
        /// Atualiza informações do registro de login, como data e geração de novo token
        /// </summary>
        /// <param name="idUsuario"></param>
        public void AtualizarRegistroAcessoLogin(int idUsuario)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Id == idUsuario);

            usuario.UltimoLogin = DateTime.Now;
            usuario.DataAtualizacao = DateTime.Now;
            usuario.Token = Guid.NewGuid().ToString();
        }
    }
}
