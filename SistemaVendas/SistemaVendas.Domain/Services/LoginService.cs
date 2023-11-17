using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using System.Text;

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

		public string geratePassword()
		{

			const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$&*";

			StringBuilder senha = new StringBuilder();
			Random random = new Random();

			for (int i = 0; i < 6; i++)
			{
				int index = random.Next(0, caracteres.Length);
				senha.Append(caracteres[index]);
			}

			return senha.ToString();
		}

		public Login GetLogin(string email, string? password)
        {
            return _loginRepository.GetLogin(email, password);
        }

	}
}
