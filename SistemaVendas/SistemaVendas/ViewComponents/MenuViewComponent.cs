using Ardalis.GuardClauses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Application.Interface;
using SistemaVendas.ViewModels;

namespace SistemaVendas.Controllers
{
    public class MenuViewComponent : ViewComponent
    {
       
        public readonly IMenuAppService _menuAppService;
        private readonly IMapper _mapper;

        public MenuViewComponent(IMenuAppService menuAppService, IMapper mapper)
        {
            _menuAppService = Guard.Against.Null(menuAppService, nameof(menuAppService));
            _mapper = mapper;

        }

        // GET: MenuController
       
        //public IViewComponentResult Invoke()
        //{
        //  var teste =  _menuRepository.Consulta().OrderBy(m => m.Nome);

        //    return View(teste);
        //}


        public async Task<IViewComponentResult> InvokeAsync()
        {

            //var t = await _menuAppService.GetMenu();
            //var menu = await _menuAppService.GetAll();
            var menuItems = _mapper.Map<IEnumerable<MenuViewModel>>(await _menuAppService.GetMenu());

            return View(menuItems);
        }

    }

}
