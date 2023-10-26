using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.ViewModels
{
    public class ClientViewModel
    {
        public int Id_Cliente { get; set; }

        public string Nome { get; set; } = null!;

        public string Sexo { get; set; } = null!;

        public string Cpf { get; set; } = null!;

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public DateTime? Data_cadastro { get; set; }

        public virtual ICollection<SaleViewModel> Sales { get; set; } = new List<SaleViewModel>();
    }
}
