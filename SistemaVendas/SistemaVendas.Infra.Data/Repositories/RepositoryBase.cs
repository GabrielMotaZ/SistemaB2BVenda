using Microsoft.EntityFrameworkCore;
using SistemaVendas.Contexto;
using SistemaVendas.Domain.Interfaces.Repositories;

namespace SistemaVendas.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {


        private readonly SistemaContext _sistemaContext;
        public RepositoryBase(SistemaContext sistemaContext)
        {
            _sistemaContext = sistemaContext;
        }

        public void Add(TEntity entity)
        {
            _sistemaContext.Add(entity);
            _sistemaContext.SaveChanges();
        }



        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _sistemaContext.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _sistemaContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _sistemaContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _sistemaContext.Entry(entity).State = EntityState.Modified;
            _sistemaContext.SaveChanges();
        }
    }
}
