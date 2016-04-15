using System.Runtime.Serialization;

namespace API.Models
{
    public class Telefone
    {
        [DataMember]
        public string CodigoArea { get; set; }

        [DataMember]
        public string Numero { get; set; }
    }
}