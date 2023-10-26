using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Application.Interface;
using SistemaVendas.ViewModels;

namespace SistemaVendas.Controllers
{
    public class MenuTopoViewComponent : ViewComponent
    {
        //public readonly IMenuRepository _menuRepository;
        public readonly IMenuTopoAppService _menuTopoAppService;
        public readonly IMapper _mapper;

        public MenuTopoViewComponent(IMenuTopoAppService menuTopoAppService, IMapper mapper)
        {
            _menuTopoAppService = Guard.Against.Null(menuTopoAppService, nameof(menuTopoAppService));
            _mapper = Guard.Against.Null(mapper, nameof(mapper));
        }

        // GET: MenuController

        //public IViewComponentResult Invoke()
        //{
        //  var teste =  _menuRepository.Consulta().OrderBy(m => m.Nome);

        //    return View(teste);
        //}


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuTopo = _mapper.Map<IEnumerable<MenuTopoViewModel>>(await _menuTopoAppService.GetMenuTop());

            return View("MenuTopoDefault", menuTopo);
        }

    }

}
