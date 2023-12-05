using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {

        IEnumerable<Employee> GetEmployee(string nome);
    }
}
