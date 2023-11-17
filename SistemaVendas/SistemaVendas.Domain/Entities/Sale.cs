using System;
using System.Collections.Generic;

namespace SistemaVendas.Domain.Entities;

public partial class Sale
{
    //public int IdVendas { get; set; }

    //public int NumVendas { get; set; }

    //public int IdProduto { get; set; }

    //public int IdCliente { get; set; }

    //public int Quantidade { get; set; }

    //public decimal? Valor { get; set; }

    //public string? Funcionario { get; set; }

    //public DateTime? DataVenda { get; set; }

    //public virtual Client IdClienteNavigation { get; set; } = null!;

    //public virtual Product IdProdutoNavigation { get; set; } = null!;



    //public int IdVendas { get; set; }

    //public int NumVendas { get; set; }
    //public string nomeProduto { get; set; }
    //public string nomeCliente { get; set; }

    //public int IdProduto { get; set; }

    //public int IdCliente { get; set; }

    //public int Quantidade { get; set; }

    //public decimal? Valor { get; set; }
    //public decimal? valorVenda { get; set; }

    //public string? Funcionario { get; set; }

    //public DateTime? DataVenda { get; set; }

    //public virtual Client IdClienteNavigation { get; set; } = null!;

    //public virtual Product IdProdutoNavigation { get; set; } = null!;


    public int IdVendas { get; set; }

    public int NumVendas { get; set; }

    public int IdProduto { get; set; }

    public int IdCliente { get; set; }

    public int Quantidade { get; set; }

    public decimal? Valor { get; set; }

    public int? IdFuncionario { get; set; }

    public DateTime? DataVenda { get; set; }

    public virtual Client IdClienteNavigation { get; set; } = null!;

    public virtual Employee? IdFuncionarioNavigation { get; set; }

    public virtual Product IdProdutoNavigation { get; set; } = null!;
}
