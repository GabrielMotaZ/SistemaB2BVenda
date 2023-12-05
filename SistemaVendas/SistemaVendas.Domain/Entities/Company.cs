using System;
using System.Collections.Generic;

namespace SistemaVendas.Domain.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Cnpj { get; set; }

    public string? InscricaoEstadual { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public string? Rua { get; set; }

    public string? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public string? Cidade { get; set; }

    public string? Uf { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<CompanyGroup> CompanyGroups { get; set; } = new List<CompanyGroup>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
