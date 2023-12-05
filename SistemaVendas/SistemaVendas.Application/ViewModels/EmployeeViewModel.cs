using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Application.ViewModels
{
    public class EmployeeViewModel
    {

        [Key]
        public int IdFunc { get; set; }


        [Required, Display(Name = "Nome")]
        public string Nome { get; set; }


        [Required, Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [MaxLength(14),MinLength(14)]
        [Required, Display(Name = "CPF")]
        public string Cpf { get; set; }


        [Required, Display(Name = "Endereço")]
        public string Endereco { get; set; }

		[MaxLength(16), MinLength(14)]
		[Required, Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        [Required, Display(Name = "Email")]
        public string Email { get; set; }


        [Required, Display(Name = "Turno")]
        public string Turno { get; set; }


        
        [DataType(DataType.Date)]
		[Required, Display(Name = "DataContratado")]
		public DateTime DataContratado { get; set; }

		public virtual ICollection<CompanyGroupViewModel> CompanyGroups { get; set; } = new List<CompanyGroupViewModel>();

		public virtual ICollection<LoginViewModel> Logins { get; set; } = new List<LoginViewModel>();

		public virtual ICollection<SaleViewModel> Sales { get; set; } = new List<SaleViewModel>();

    }
}
