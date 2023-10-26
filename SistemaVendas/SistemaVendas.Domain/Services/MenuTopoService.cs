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
    public class MenuTopoService : ServiceBase<MenuTopo>, IMenuTopoService
    {
        private readonly IMenuTopoRepository _menuTopoRepository;

        public MenuTopoService(IMenuTopoRepository menuTopoRepository) 
            : base(menuTopoRepository)
        {
            _menuTopoRepository = menuTopoRepository;
        }

        public async Task<IEnumerable<MenuTopo>> GetMenuTop()
        {
           return await _menuTopoRepository.GetMenuTop();  
        }
    }
}
