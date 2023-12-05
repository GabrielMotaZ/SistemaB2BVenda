using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface IDashboardRepository
    {
        IEnumerable<Dashboard> DashboardByWeek();
    }
}
