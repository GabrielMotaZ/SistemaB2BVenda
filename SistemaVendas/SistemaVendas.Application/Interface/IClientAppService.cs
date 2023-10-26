using SistemaVendas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.Interface
{
    public interface IClientAppService
    {

        IEnumerable<ClientViewModel>  getClient();
    }
}
