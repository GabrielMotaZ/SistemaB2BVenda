using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Domain.Services
{
    public class SaleService : ServiceBase<Sale>, ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository)
            : base(saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IEnumerable<Sale> ListSales()
        {
            return _saleRepository.ListSales();
        }
    }
}
