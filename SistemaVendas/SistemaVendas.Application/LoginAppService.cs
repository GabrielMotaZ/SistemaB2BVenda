using Ardalis.GuardClauses;
using AutoMapper;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;

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

        public LoginViewModel GetLogin(string email, string? password)
        {
            try
            {
                var login = _loginService.GetLogin(email, password);

                if (login.Data == null)
                {
                    throw new NullReferenceException("Vamos validar sua senha!!!");
                }

                return _mapper.Map<LoginViewModel>(login);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("usuario ou senha invalido");
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public LoginViewModel GetLoginId(int id)
        {
            var loginMap = _loginService.GetById(id);

            var mapLogi = _mapper.Map<LoginViewModel>(loginMap);
            return mapLogi;
        }

        public void CreateLogin(LoginViewModel loginViewModel)
        {
            var login = _mapper.Map<Login>(loginViewModel);

            _loginService.Add(login);
        }

        public void UpdateLogin(int id, LoginViewModel loginViewModel)
        {

            try
            {
                var valida = _loginService.GetLogin(loginViewModel.Email, null);

                if (loginViewModel.Senha == loginViewModel.newPassword)
                {
                    throw new Exception("Nova senha deve ser diferenre da antiga senha!!!");
                }
                else if (loginViewModel.Senha != valida.Senha)
                {
                    throw new InvalidOperationException("senha do email invalida!!");
                }


                valida.Data = DateTime.Now;
                valida.Senha = loginViewModel.newPassword;

                var login = _mapper.Map<Login>(valida);

                _loginService.Update(login);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}
