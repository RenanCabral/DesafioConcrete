using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace API.Models
{
    public class Usuario
    {
        public Usuario(string nome, string email, string token)
        {
            this.Nome = nome;
            this.Email = email;
            this.Token = token;
        }

        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Email { get; set; }
        
        [IgnoreDataMember]
        public string Token { get; set; }

        [DataMember]
        public string Senha { get; set; }

        [DataMember]
        public List<Telefone> Telefones { get; set; }

        public static Usuario CriarUsuarioModel(Domain.Usuario usuario)
        {
            if (!UsuarioValido(usuario))
                return null;

           var usuarioModel = new Usuario(usuario.Nome, usuario.Email, usuario.Token);
            usuarioModel.Id = usuario.Id;

            //TODO: implementar e utilizar o 'ConvertAll'
            if (usuario.Telefones != null)
            {
                usuarioModel.Telefones = new List<Models.Telefone>();
                foreach (var telefone in usuario.Telefones)
                {
                    usuarioModel.Telefones.Add(new Models.Telefone() { CodigoArea = telefone.CodigoArea, Numero = telefone.Numero });
                };
            }

            return usuarioModel;
        }

        public static Domain.Usuario CriarUsuarioDomain(Models.Usuario usuario)
        {
            var usuarioDomain = new Domain.Usuario(usuario.Nome, usuario.Email, usuario.Senha, Guid.NewGuid().ToString());

            usuarioDomain.DataCriacao = DateTime.Now;
            usuarioDomain.UltimoLogin = DateTime.Now;

            //TODO: implementar e utilizar o 'ConvertAll'
            if (usuario.Telefones != null)
            {
                usuarioDomain.Telefones = new List<Domain.Telefone>();
                foreach (var telefone in usuario.Telefones)
                {
                    usuarioDomain.Telefones.Add(new Domain.Telefone() { CodigoArea = telefone.CodigoArea, Numero = telefone.Numero });
                };
            }

            return usuarioDomain;
        }

        private static bool UsuarioValido(Domain.Usuario usuario)
        {
            return usuario != null;
        }

    }
}