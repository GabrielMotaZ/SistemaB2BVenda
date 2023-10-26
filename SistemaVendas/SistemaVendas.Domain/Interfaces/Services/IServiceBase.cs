

namespace SistemaVendas.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Delete(int id);

        void Dispose();
        void Remove<TEntity>(TEntity obj) where TEntity : class;
    }
}
