using SistemaVendas.Application.ViewModels;
using SistemaVendas.Domain.Entities;


namespace SistemaVendas.Application.Interface
{
    public interface IEmployeeAppService : IAppServiceBase<Employee>
    {
        IEnumerable<EmployeeViewModel> GetEmployee(string nome);
        EmployeeViewModel GetEmployeeId(int id);

        void CreateEmployee(EmployeeViewModel employeeViewModel);

        void UpdateEmployee(int id, EmployeeViewModel employeeViewModel);
    }
}
