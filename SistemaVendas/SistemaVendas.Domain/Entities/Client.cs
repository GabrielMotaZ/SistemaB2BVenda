

namespace SistemaVendas.Domain.Entities
{

    public class Client
    {
        public int Id_Cliente { get; set; }

        public string Nome { get; set; } = null!;

        public string Sexo { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public DateTime? Data_cadastro { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }

}
