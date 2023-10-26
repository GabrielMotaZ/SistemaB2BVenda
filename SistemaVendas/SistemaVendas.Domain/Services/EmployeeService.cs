using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;


namespace SistemaVendas.Domain.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
            : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployee(string nome)
        {
            return _employeeRepository.GetEmployee(nome);
        }
    }
}
