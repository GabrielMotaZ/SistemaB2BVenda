using SistemaVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IEmployeeService : IServiceBase<Employee>
    {
        IEnumerable<Employee> GetEmployee(string nome);

        void CreateEmployee(Employee employee);
    }
}
