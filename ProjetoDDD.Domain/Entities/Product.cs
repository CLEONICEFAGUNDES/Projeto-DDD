namespace ProjetoDDD.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        
        public string Nome { get; set;}

        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }
    }
}
