using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface ICompanyService : IServiceBase<Company>
    {
        IEnumerable<Company> GetCompany();
    }
}
