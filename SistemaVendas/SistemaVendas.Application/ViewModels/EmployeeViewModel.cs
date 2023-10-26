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
        public string nome { get; set; }


        [Required, Display(Name = "Sexo")]
        public string sexo { get; set; }


        [RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
        [Required, Display(Name = "CPF")]
        public string cpf { get; set; }


        [Required, Display(Name = "Endereço")]
        public string endereco { get; set; }


        [RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
        [Required, Display(Name = "Telefone")]
        public string telefone { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        [Required, Display(Name = "Email")]
        public string email { get; set; }


        [Required, Display(Name = "Turno")]
        public string turno { get; set; }

		
		[DataType(DataType.Date)]
		[Required, Display(Name = "DataContratado")]
		public DateTime DataContratado { get; set; }

    }
}
