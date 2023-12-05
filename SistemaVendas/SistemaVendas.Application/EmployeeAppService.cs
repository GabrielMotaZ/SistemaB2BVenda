using AutoMapper;
using SistemaVendas.Application.Interface;
using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Services;


namespace SistemaVendas.Application
{
    public class EmployeeAppService : AppServiceBase<Employee>, IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;

        private readonly ILoginService _loginService;


        private readonly IEmailService    _emailService;
        private readonly IMapper _mapper;   

        public EmployeeAppService(IEmployeeService employeeService, IMapper mapper, ILoginService loginService, IEmailService emailService)
            : base(employeeService) 
        {
            _employeeService = employeeService;
			_loginService = loginService;
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
            

            var createMap       = _mapper.Map<Employee>(employeeViewModel);

            createMap.Cpf       = createMap.Cpf.Replace(".", "").Replace("-", "");
            createMap.Telefone  = createMap.Telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            _employeeService.Add(createMap);

            var senha = _loginService.geratePassword();


           var login = (new LoginViewModel
            {
				Email       = createMap.Email,
			    Senha       = senha,
			    Data        = null,
			    IdEmployee  = createMap.IdFunc,
		    });


            var user = _mapper.Map<Login>(login);

            _loginService.Add(user);

    
			_emailService.EmailPassword(createMap.Email,  createMap.Nome, senha);


        }

        public void UpdateEmployee(int id, EmployeeViewModel employeeViewModel)
        {
           employeeViewModel.IdFunc = id;

			employeeViewModel.Cpf           = employeeViewModel.Cpf.Replace(".", "").Replace("-", "");
			employeeViewModel.Telefone      = employeeViewModel.Telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

			var emp = _mapper.Map<Employee>(employeeViewModel);

            _employeeService.Update(emp);
        }
    }
}
