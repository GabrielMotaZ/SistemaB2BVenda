using SistemaVendas.Contexto;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Infra.Data.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        private readonly ConexaoContext _conexaoContext;
        private readonly SistemaContext _sistemaContext;
        public CompanyRepository(SistemaContext sistemaContext, ConexaoContext conexaoContext)
            : base(sistemaContext)
        {
            _conexaoContext = conexaoContext;
            _sistemaContext = sistemaContext;
        }

        public IEnumerable<Company> GetCompany()
        {
            throw new NotImplementedException();
        }
    }
}
