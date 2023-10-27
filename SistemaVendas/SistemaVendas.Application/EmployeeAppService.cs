using AutoMapper;
using SistemaVendas.Application.Interface;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;
using SistemaVendas.ViewModels;
using System;
using System.Text;

namespace SistemaVendas.Application
{
    public class EmployeeAppService : AppServiceBase<Employee>, IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;

        //CORRIGIR -- Verificar essa injeção
        private readonly ILoginAppService _loginAppService;


        private readonly IEmailService    _emailService;
        private readonly IMapper _mapper;   

        public EmployeeAppService(IEmployeeService employeeService, IMapper mapper, ILoginAppService loginAppService, IEmailService emailService)
            : base(employeeService) 
        {
            _employeeService = employeeService;
            _loginAppService = loginAppService;
            _emailService = emailService;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeViewModel> GetEmployee(string nome)
        {
            object getEmployee;

			if (nome == null) {
				 getEmployee = _employeeService.GetAll();
			}
            else
            {
                getEmployee = _employeeService.GetEmployee(nome);

			}
            
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(getEmployee);

        }

        public EmployeeViewModel GetEmployeeId(int id)
        {
            var getEmployeeId = _employeeService.GetById(id);

            return _mapper.Map<EmployeeViewModel>(getEmployeeId);
        }

        public void CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            var login = new LoginViewModel();

            var createMap = _mapper.Map<Employee>(employeeViewModel);

            _employeeService.Add(createMap);

            var senha = _loginAppService.geratePassword();

           
            login.Nome = createMap.Nome;
            login.Senha = senha;
            login.Data = DateTime.Now;
            login.IdEmployee = createMap.IdFunc;


            var user = _mapper.Map<LoginViewModel>(login);

            _loginAppService.CreateLogin(user);

    
			_emailService.SendEmail(createMap.Email,  createMap.Nome, senha);


        }

        public void UpdateEmployee(int id, EmployeeViewModel employeeViewModel)
        {
           employeeViewModel.IdFunc = id;

           var emp = _mapper.Map<Employee>(employeeViewModel);

            _employeeService.Update(emp);
        }
    }
}
