using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface ILoginService : IServiceBase<Login>
    {
        Login GetLogin(string email, string? password);

        string geratePassword();

    }
}
