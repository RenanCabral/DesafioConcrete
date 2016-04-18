using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {

        public Usuario(string nome, string email, string senha, string token)
        {   
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Token = token;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime UltimoLogin { get; set; }

        public List<Telefone> Telefones { get; set; }
    }

}
