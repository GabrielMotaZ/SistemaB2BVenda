using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.ViewModels
{
    public class EmployeeViewModel
    {

        //public IEnumerable<MenuViewModel> menu { get; set; }
        //public IEnumerable<EmployeeViewModel> funcionario { get; set; }


        //public SubMenu SubMenu { get; set; }

        [Key]
        public int IdFunc { get; set; }


        [Required, Display(Name = "Nome")]
        public string Nome { get; set; }


        [Required, Display(Name = "Sexo")]
        public string Sexo { get; set; }


        [RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
        [Required, Display(Name = "CPF")]
        public string Cpf { get; set; }


        [Required, Display(Name = "Endereço")]
        public string Endereco { get; set; }


        [RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
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

        public virtual ICollection<SaleViewModel> Sales { get; set; } = new List<SaleViewModel>();

    }
}
