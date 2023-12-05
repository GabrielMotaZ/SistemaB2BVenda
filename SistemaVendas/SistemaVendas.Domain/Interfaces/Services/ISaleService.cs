using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface ISaleService : IServiceBase<Sale>
    {
        IEnumerable<Sale> ListSales();
    }
}
