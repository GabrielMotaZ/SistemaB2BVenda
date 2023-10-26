


using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface ILoginService : IServiceBase<Login>
    {
        IEnumerable<Login> QueryLogin(Login login);
    }
}
