using System;
using System.Collections.Generic;

namespace SistemaVendas.Contexto;

public partial class Product
{
    public int IdProduto { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int Quantidade { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? DataCadastro { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
