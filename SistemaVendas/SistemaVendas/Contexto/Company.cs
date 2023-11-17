using System;
using System.Collections.Generic;

namespace SistemaVendas.Contexto;

public partial class Company
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Cnpj { get; set; }

    public string? Endereco { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
