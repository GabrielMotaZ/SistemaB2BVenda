using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IMenuTopoService : IServiceBase<MenuTopo>
    {
        Task<IEnumerable<MenuTopo>> GetMenuTop();
    }
}
