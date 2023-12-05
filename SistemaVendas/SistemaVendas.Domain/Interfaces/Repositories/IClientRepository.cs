using SistemaVendas.Domain.Entities;

namespace SistemaVendas.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepositoryBase<Client>
    {

        IEnumerable<Client> GetClient();
        IEnumerable<Client> PostClient(Client client);
    }
}
