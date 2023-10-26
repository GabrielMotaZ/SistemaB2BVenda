using SistemaVendas.Domain.Interfaces.Repositories;
using SistemaVendas.Domain.Interfaces.Services;


namespace SistemaVendas.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(TEntity entity)
        {
            _repositoryBase.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _repositoryBase.GetById(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(TEntity entity)
        {
            _repositoryBase.Update(entity);
        }

        void IServiceBase<TEntity>.Remove<TEntity1>(TEntity1 obj)
        {
            throw new NotImplementedException();
        }
    }
}
