using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Infra.Data.Contexto
{
    public class ConexaoContext : SimpleDBContext
    {
        public ConexaoContext(IConfiguration configuration)
            : base(configuration.GetConnectionString("VendaConnection"))
        {

        }
    }
}
