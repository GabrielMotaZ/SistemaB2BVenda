﻿using SistemaVendas.Application.Interface;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Application
{
    public class MenuAppService : AppServiceBase<Menu>, IMenuAppService
    {
        private readonly IMenuService _menuService;
        public MenuAppService(IMenuService menuService)
            : base(menuService)
        {
            _menuService = menuService;
        }

        public async Task<IEnumerable<Menu>> GetMenu()
        {
            return await _menuService.GetMenu();
        }
    }
}
