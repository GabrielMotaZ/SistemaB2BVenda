using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Interface
{
    public interface IMenuTopoAppService : IAppServiceBase<MenuTopo>
    {
        Task<IEnumerable<MenuTopo>> GetMenuTop();
    }
}
