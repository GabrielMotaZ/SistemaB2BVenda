using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IDashboardService
    {
        IEnumerable<Dashboard> DashboardByWeek();
    }
}
