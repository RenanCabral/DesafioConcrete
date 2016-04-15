using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace API.Models
{
    public class Usuario
    {
        public Usuario(string nome, string email)
        {
            this.Nome = nome;
            this.Email = email;
        }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public string Senha { get; set; }

        [DataMember]
        public List<Telefone> Telefones { get; set; }

        public static Usuario CriarUsuario(Domain.Usuario usuario)
        {
            if (!UsuarioValido(usuario))
                return null;

            return new Usuario(usuario.Nome, usuario.Email);
        }

        private static bool UsuarioValido(Domain.Usuario usuario)
        {
            return usuario != null;
        }

    }
}