using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.ViewModels
{
    public class MenuViewModel
    {
        //[Key]
        public int id { get; set; }

        [Required]
        public string Nome { get; set; }


        [Required]
        public string Action { get; set; }

        [Required]
        public string Controller { get; set; }

        public bool Habilitado { get; set; }

        public IEnumerable<SubMenuViewModel> SubMenu { get; set; }

        //public SubMenu itemSubmenu { get; set; }
    }
}
