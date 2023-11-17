using System;
using System.Collections.Generic;

namespace SistemaVendas.Contexto;

public partial class Client
{
    public int IdCliente { get; set; }

    public string Nome { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
