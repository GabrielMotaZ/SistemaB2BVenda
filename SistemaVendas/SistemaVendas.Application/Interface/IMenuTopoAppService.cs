using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Application.Interface
{
    public interface IMenuTopoAppService : IAppServiceBase<MenuTopo>
    {
        Task<IEnumerable<MenuTopo>> GetMenuTop();
    }
}
