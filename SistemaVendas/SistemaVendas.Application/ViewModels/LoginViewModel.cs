using SistemaVendas.Domain.Entities;

namespace SistemaVendas.ViewModels
{
    public class LoginViewModel
    {
        public int IdLogin { get; set; }

        public string? Nome { get; set; }

        public string? Senha { get; set; }

        public DateTime? Data { get; set; }

        public int? IdAcessos { get; set; }

        public int? IdEmployee { get; set; }

        public virtual Acesso? IdAcessosNavigation { get; set; }
    }
}
