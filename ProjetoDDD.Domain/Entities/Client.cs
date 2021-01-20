using System;
using System.Collections.Generic;

namespace ProjetoDDD.Domain.Entities
{
    public class Client
    {
        public int ClientID { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public bool ClientEspecial(Client client)
        {
            return client.Ativo && DateTime.Now.Year - client.DataCadastro.Year >= 5;
        }
    }
}
