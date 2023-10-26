using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SistemaVendas.ViewComponents
{
    public class CadastroModalViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        public CadastroModalViewComponent(IMapper mapper) { _mapper = mapper; }

		public IViewComponentResult Invoke()
		{
			return View("_CadastroModal");
		}
	}
}
