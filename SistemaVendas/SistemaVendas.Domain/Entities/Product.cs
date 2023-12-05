namespace SistemaVendas.Domain.Entities
{
    public class Product
    {

        public int id_produto { get; set; }

        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public int Quantidade { get; set; }

        public decimal? Valor { get; set; }

        public DateTime? DataCadastro { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();


    }
}
