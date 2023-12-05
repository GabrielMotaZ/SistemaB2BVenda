using AutoMapper;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Application
{
    public class CompanyAppService : AppServiceBase<Company>, ICompanyAppService
    {

        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyAppService(ICompanyService companyService, IMapper mapper)
            : base(companyService)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public void CreateCompany(CompanyViewModel companyViewModel)
        {
            var create = _mapper.Map<Company>(companyViewModel);

            create.DataCadastro = DateTime.Now;
            create.Cnpj = create.Cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            create.Cep = create.Cep.Replace("-", "");
            create.InscricaoEstadual = create.InscricaoEstadual.Replace(".", "");
            create.Telefone = create.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            _companyService.Add(create);
        }

        public IEnumerable<CompanyViewModel> GetCompany()
        {
            var company = _companyService.GetCompany();

            return _mapper.Map<IEnumerable<CompanyViewModel>>(company);
        }

        public CompanyViewModel GetCompanyId(int id)
        {
            var update = _companyService.GetById(id);

            update.Cnpj = $"{Convert.ToInt64(update.Cnpj):00\\.000\\.000\\/0000\\-00}";
            update.Cep = $"{Convert.ToInt64(update.Cep):00000\\-000}";
            update.InscricaoEstadual = $"{Convert.ToInt64(update.InscricaoEstadual):000\\.000\\.000\\.000}";



            if (update.Telefone.Length == 11)
            {
                update.Telefone = $"{Convert.ToInt64(update.Telefone):\\(##\\)\\ #\\ ####\\-####}";
            }
            else
            {
                update.Telefone = $"{Convert.ToInt64(update.Telefone):\\(##\\)\\ ####\\-####}";
            }





            return _mapper.Map<CompanyViewModel>(update);
        }

        public void UpdateCompany(int id, CompanyViewModel companyViewModel)
        {
            companyViewModel.Id = id;
            companyViewModel.Cnpj = companyViewModel.Cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            companyViewModel.Cep = companyViewModel.Cep.Replace("-", "");
            companyViewModel.InscricaoEstadual = companyViewModel.InscricaoEstadual.Replace(".", "");
            companyViewModel.Telefone = companyViewModel.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            var update = _mapper.Map<Company>(companyViewModel);

            _companyService.Update(update);
        }
    }
}
