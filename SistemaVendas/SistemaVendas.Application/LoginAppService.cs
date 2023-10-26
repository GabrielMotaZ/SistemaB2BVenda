
using AutoMapper;
using Ardalis.GuardClauses;
using SistemaVendas.Application.Interface;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;
using SistemaVendas.ViewModels;
using System.Text;

namespace SistemaVendas.Application
{
    public class LoginAppService : AppServiceBase<Login>, ILoginAppService
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginAppService(ILoginService loginService, IMapper mapper)
            : base(loginService)
        {
            _loginService = Guard.Against.Null(loginService, nameof(loginService));
            _mapper = mapper;

        }

        public void  CreateLogin(LoginViewModel loginViewModel)
        {
            var login = _mapper.Map<Login>(loginViewModel);

            _loginService.Add(login);
        }

        public string geratePassword()
        {

            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";

            StringBuilder senha = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(0, caracteres.Length);
                senha.Append(caracteres[index]);
            }

            return senha.ToString();
        }

        public IEnumerable<LoginViewModel> QueryLogin(LoginViewModel loginViewModel)
        {

            var login = _loginService.QueryLogin( _mapper.Map<Login>(loginViewModel));

            return  _mapper.Map<IEnumerable<LoginViewModel>>(login);
        }


    }
}
