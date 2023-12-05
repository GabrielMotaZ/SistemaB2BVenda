using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Application.Interface;

namespace SistemaVendas.ViewComponents
{

    public class DashboardViewComponent : ViewComponent
    {
        private readonly IDashboardAppService _dashboardAppService;

        //private readonly ISaleAppService _saleAppService;
        public DashboardViewComponent(IDashboardAppService dashboardAppService)
        {
            _dashboardAppService = dashboardAppService;
        }


        public IViewComponentResult Invoke()
        {
            var dash = _dashboardAppService.DashboardByWeek();
            return View(dash);
        }



    }
}
