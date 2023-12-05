using SistemaVendas.Application.ViewModels;

namespace SistemaVendas.Application.Interface
{
    public interface IClientAppService
    {

        IEnumerable<ClientViewModel> getClient();

        ClientViewModel getClientId(int id);
    }
}
