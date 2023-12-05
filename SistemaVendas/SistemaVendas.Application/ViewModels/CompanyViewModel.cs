using System.ComponentModel.DataAnnotations;


namespace SistemaVendas.Application.ViewModels
{
    public class CompanyViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Nome")]
        public string? Nome { get; set; }

        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
        [MaxLength(18)]
        [Required, Display(Name = "CNPJ")]
        public string? Cnpj { get; set; }

        [MaxLength(15)]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
        [Required, Display(Name = "Inscrição Estatual")]
        public string? InscricaoEstadual { get; set; }

        [Required, Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido.")]
        public string? Email { get; set; }

        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
        [MaxLength(16), MinLength(14)]
        [Required, Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Required, Display(Name = "Rua")]
        public string? Rua { get; set; }

        [Required, Display(Name = "Numero")]
        public string? Numero { get; set; }

        [Required, Display(Name = "Bairro")]
        public string? Bairro { get; set; }

        [MaxLength(9)]
        [Required, Display(Name = "CEP")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "somente números.")]
        public string? Cep { get; set; }

        [Required, Display(Name = "Cidade")]
        public string? Cidade { get; set; }

        [MaxLength(2)]
        [Required, Display(Name = "UF")]
        public string? Uf { get; set; }


        [DataType(DataType.Date)]
        [Required, Display(Name = "DataContratado")]
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<CompanyGroupViewModel> CompanyGroups { get; set; } = new List<CompanyGroupViewModel>();

        public virtual ICollection<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

    }
}
