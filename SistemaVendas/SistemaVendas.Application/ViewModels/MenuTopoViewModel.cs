using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Application.ViewModels
{
    public class MenuTopoViewModel
    {
        public int id { get; set; }

        [Required]
        public string Nome { get; set; }


        [Required]
        public String Action { get; set; }
        [Required]
        public String Controller { get; set; }

        public bool Habilitado { get; set; }

        //public IEnumerable<SubMenu> SubMenu { get; set; }

        //public SubMenu itemSubmenu { get; set; }
    }
}

