using SistemaVendas.Application.Interface;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Application
{
    public class MenuTopoAppService : AppServiceBase<MenuTopo>, IMenuTopoAppService
    {
        private readonly IMenuTopoService _menuTopoService;

        public MenuTopoAppService(IMenuTopoService menuTopoService)
            : base(menuTopoService)
        {
            _menuTopoService = menuTopoService;
        }

        public async Task<IEnumerable<MenuTopo>> GetMenuTop()
        {
            return await _menuTopoService.GetMenuTop();
        }
    }
}
