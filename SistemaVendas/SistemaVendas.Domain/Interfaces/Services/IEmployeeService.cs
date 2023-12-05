using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IEmployeeService : IServiceBase<Employee>
    {
        IEnumerable<Employee> GetEmployee(string nome);

        void CreateEmployee(Employee employee);
    }
}
