using AutoMapper;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Application
{
    public class SaleAppService : AppServiceBase<Sale>, ISaleAppService
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        public SaleAppService(ISaleService saleService, IMapper mapper) 
            : base(saleService)
        {
            _saleService = saleService;   
            _mapper = mapper;
        }

        public IEnumerable<SaleViewModel> ListSales()
        {
            var sales = _saleService.ListSales();

            return  _mapper.Map<IEnumerable<SaleViewModel>>(sales);
        } 
    }
}
