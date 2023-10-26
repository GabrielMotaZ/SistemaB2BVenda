using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.ViewModels
{
    public class SubMenuViewModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public String Action { get; set; }
        [Required]
        public String Controller { get; set; }

        public bool Habilitado { get; set; }
        public int idMenu { get; set; }
    }
}
