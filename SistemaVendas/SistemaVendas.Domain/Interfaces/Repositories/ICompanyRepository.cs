﻿using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {

        IEnumerable<Company> GetCompany();
    }
}
