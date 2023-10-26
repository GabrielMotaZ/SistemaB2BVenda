using SistemaVendas.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.ViewModels
{
    public class SaleViewModel
    {
        //public Menu menu { get; set; }
        //public SubMenu SubMenu { get; set; }

        //public int idVenda { get; set; }
        //public int numVenda { get; set; }

        //[Display(Name = "Produto")]
        //public string nomeProduto { get; set; }

        //[Display(Name = "Cliente")]
        //public string nomeCliente { get; set; }

        //[Display(Name = "Valor do produto")]
        //public Decimal valorProduto { get; set; }

        //[Display(Name = "Quantidade de Vendas")]
        //public int quantidadeVenda { get; set; }

        //[Display(Name = "Valor da venda")]
        //public Decimal valorVenda { get; set; }

        //[Display(Name = "Colaborador")]
        //public string colaborador { get; set; }

        //[Display(Name = "Data venda")]
        //[DataType(DataType.Date)]
        //public DateTime dataVenda { get; set; }
        //public int idVendaProduto { get; set; }
        //public int idVendaCliente { get; set; }



        public int IdVendas { get; set; }

        public int NumVendas { get; set; }

        public string nomeProduto { get; set; }
        public string nomeCliente { get; set; }

        public int IdProduto { get; set; }

        public int IdCliente { get; set; }

        public int Quantidade { get; set; }

        public decimal? Valor { get; set; }

        public decimal? valorVenda { get; set; }

        public string? Funcionario { get; set; }

        public DateTime? DataVenda { get; set; }

        public virtual Client IdClienteNavigation { get; set; } = null!;

        public virtual Product IdProdutoNavigation { get; set; } = null!;
    }
}
