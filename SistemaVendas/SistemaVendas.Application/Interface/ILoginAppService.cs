using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;


namespace SistemaVendas.Application.Interface
{
    public interface ILoginAppService : IAppServiceBase<Login>
    {

        LoginViewModel GetLogin(string email, string? password);

		LoginViewModel GetLoginId(int id);

		void CreateLogin(LoginViewModel loginViewModel);

        void UpdateLogin(int id, LoginViewModel loginViewModel);
      
       
     
    }
}
