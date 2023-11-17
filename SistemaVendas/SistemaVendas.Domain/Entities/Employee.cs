

namespace SistemaVendas.Domain.Entities;

public partial class Employee
{
    public int IdFunc { get; set; }

    public string Nome { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Turno { get; set; }

    public DateTime? DataContratado { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
