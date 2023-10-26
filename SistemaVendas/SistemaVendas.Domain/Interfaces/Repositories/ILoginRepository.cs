
using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface ILoginRepository : IRepositoryBase<Login>
    {
        IEnumerable<Login> QueryLogin(Login login);
    }
}
