using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Domain.Services
{
    public class LoginService : ServiceBase<Login>, ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
            : base(loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IEnumerable<Login> QueryLogin(Login login)
        {
            return _loginRepository.QueryLogin(login);
        }
    }
}
