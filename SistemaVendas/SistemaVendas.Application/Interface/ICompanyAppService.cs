using SistemaVendas.Domain.Entities;
using SistemaVendas.Application.ViewModels;

namespace SistemaVendas.Application.Interface
{
    public interface ICompanyAppService : IAppServiceBase<Company>
    {
        IEnumerable<CompanyViewModel> GetCompany();

        CompanyViewModel GetCompanyId(int id);

        void CreateCompany(CompanyViewModel companyViewModel);

        void UpdateCompany(int id, CompanyViewModel companyViewModel);
    }
}
