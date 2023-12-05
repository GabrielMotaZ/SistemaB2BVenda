using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
            :base(companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IEnumerable<Company> GetCompany()
        {
            return _companyRepository.GetAll();
        }
    }
}
