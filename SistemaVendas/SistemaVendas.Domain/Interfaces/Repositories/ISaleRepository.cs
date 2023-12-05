using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface ISaleRepository : IRepositoryBase<Sale>
    {
        IEnumerable<Sale> ListSales();
    }
}
