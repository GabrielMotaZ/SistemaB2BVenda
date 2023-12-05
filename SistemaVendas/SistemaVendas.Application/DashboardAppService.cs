using AutoMapper;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Application
{
    public class DashboardAppService : IDashboardAppService
    {

        private readonly IDashboardService _dashboardService;
        private readonly IMapper _mapper;

        public DashboardAppService(IDashboardService dashboardService, IMapper mapper)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }


        public IEnumerable<DashboardViewModel> DashboardByWeek()
        {
            var dash = _dashboardService.DashboardByWeek();

            return _mapper.Map<IEnumerable<DashboardViewModel>>(dash);
        }
    }
}
