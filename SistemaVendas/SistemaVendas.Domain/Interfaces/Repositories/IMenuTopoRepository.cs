using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface IMenuTopoRepository : IRepositoryBase<MenuTopo>
    {
        Task<IEnumerable<MenuTopo>> GetMenuTop();
    }
}
