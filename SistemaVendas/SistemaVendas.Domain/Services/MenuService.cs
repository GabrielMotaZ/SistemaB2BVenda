using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Services
{
    public class MenuService : ServiceBase<Menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository) 
            : base(menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> GetMenu()
        {
            return await _menuRepository.GetMenu();
        }
    }
}
