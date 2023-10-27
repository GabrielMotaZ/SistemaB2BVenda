using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.ViewModels
{
    public class ClientViewModel
    {
        public int Id_Cliente { get; set; }


        [Required, Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required, Display(Name = "Sexo")]
        public string Sexo { get; set; }


        [Required, Display(Name = "Cpf")]
        public string Cpf { get; set; }
        
        
        [Required, Display(Name = "Endereco")]
        public string? Endereco { get; set; }
       
        
        [Required, Display(Name = "Telefone")]
        public string? Telefone { get; set; }
       
        
        [Required, Display(Name = "Email")]
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        [Required, Display(Name = "Data_cadastro")]
        public DateTime? Data_cadastro { get; set; }
       
        
        [Required, Display(Name = "Nome")]
        public virtual ICollection<SaleViewModel> Sales { get; set; } = new List<SaleViewModel>();
    }
}
