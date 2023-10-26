using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;

namespace SistemaVendas.Application.Interface
{
    public interface ISaleAppService : IAppServiceBase<Sale>
    {
        IEnumerable<SaleViewModel> ListSales();
    }
}
