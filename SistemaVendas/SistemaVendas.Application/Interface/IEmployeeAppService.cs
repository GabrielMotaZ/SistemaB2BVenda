using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
