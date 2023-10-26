using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;

namespace SistemaVendas.Application.Interface
{
    public interface ILoginAppService : IAppServiceBase<Login>
    {

        IEnumerable<LoginViewModel> QueryLogin(LoginViewModel login);

        void CreateLogin(LoginViewModel loginViewModel);

        string geratePassword();
     
    }
}
