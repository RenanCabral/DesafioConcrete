using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {

        public Usuario(int id, string nome, string email, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }

        public DateTime DataCriacao { get; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime UltimoLogin { get; set; }

        public List<Telefone> Telefones { get; set; }
    }

}
