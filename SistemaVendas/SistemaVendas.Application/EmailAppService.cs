using SistemaVendas.Application.Interface;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application
{
	public class EmailAppService : IEmailAppService
	{
		private readonly IEmailService _emailService;

		private readonly ILoginService _loginService;
		public EmailAppService(IEmailService emailService, ILoginService loginService) 
		{ 
			_emailService = emailService; 
			_loginService = loginService;
		}


		public void EmailPassword(string email, string nome)
		{
			var login = _loginService.GetLogin(email,null);
			string senha =_loginService.geratePassword();

			login.Senha = senha;
			login.Data = null;

			_loginService.Update(login);

			_emailService.EmailPassword(email, login.Nome, senha);
		}
	}
}
