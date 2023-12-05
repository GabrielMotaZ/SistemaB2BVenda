using SistemaVendas.Domain.Entities;
using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;

namespace SistemaVendas.Domain.Services
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
               : base(clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetClient()
        {
            return _clientRepository.GetClient();
        }

        public IEnumerable<Client> PostClient(Client client)
        {
            return _clientRepository.PostClient(client);
        }
    }
}
