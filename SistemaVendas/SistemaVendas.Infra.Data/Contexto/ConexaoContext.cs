using Microsoft.Extensions.Configuration;

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
