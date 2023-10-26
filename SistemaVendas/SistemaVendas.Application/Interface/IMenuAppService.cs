using SistemaVendas.Domain.Entities;


namespace SistemaVendas.Application.Interface
{
    public interface IMenuAppService : IAppServiceBase<Menu>
    {
        Task<IEnumerable<Menu>> GetMenu(); 
        
    }
}
