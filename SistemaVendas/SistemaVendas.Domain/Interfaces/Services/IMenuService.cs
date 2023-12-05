using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IMenuService : IServiceBase<Menu>
    {
        Task<IEnumerable<Menu>> GetMenu();
    }
}
