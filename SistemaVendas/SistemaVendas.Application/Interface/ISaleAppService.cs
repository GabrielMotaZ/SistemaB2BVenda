using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;


namespace SistemaVendas.Application.Interface
{
    public interface ISaleAppService : IAppServiceBase<Sale>
    {
        IEnumerable<SaleViewModel> ListSales();

        

	}
}
