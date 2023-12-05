using SistemaVendas.Application.ViewModels;

namespace SistemaVendas.Application.Interface
{
    public interface IDashboardAppService
    {
        IEnumerable<DashboardViewModel> DashboardByWeek();
    }
}
