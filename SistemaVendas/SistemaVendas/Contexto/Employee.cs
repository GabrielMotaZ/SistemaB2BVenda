using System;
using System.Collections.Generic;

namespace SistemaVendas.Contexto;

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

    public int? IdCompany { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
