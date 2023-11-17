using SistemaVendas.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.ViewModels
{
    public class LoginViewModel
    {
        public int IdLogin { get; set; }

        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string? Email { get; set; }

        [Required]
		[MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
		[MaxLength(10)]
		//[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*\W).*$",
		//ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.")]
		public string? Senha { get; set; }        
        
        [Required]
		[MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
		[MaxLength(10)]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*\W).*$",
		ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.")]
		public string? newPassword { get; set; }

        public DateTime? Data { get; set; }

        public int? IdAcessos { get; set; }

        public int? IdEmployee { get; set; }

        public virtual Acesso? IdAcessosNavigation { get; set; }
    }
}
