using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface ILoginRepository : IRepositoryBase<Login>
    {
        Login GetLogin(string email, string? password);

    }
}
