using System;
using System.Collections.Generic;
using AtendimentoHospitalar.Repositories;

namespace AtendimentoHospitalar.Services
{
    public class ServiceBase<TEntity>: IDisposable where TEntity : class
    {
        private readonly RepositoryBase<TEntity> repositoryBase = new RepositoryBase<TEntity>();

        public void Save(TEntity objEntity)
        {
            repositoryBase.Add(objEntity);
        }
        public void Update(TEntity objEntity)
        {
            repositoryBase.Update(objEntity);
        }
        public void Delete(TEntity objEntity)
        {
            repositoryBase.Remove(objEntity);
        }
        public void Delete(Guid id)
        {
            repositoryBase.Remove(id);
        }
        public TEntity GetById(Guid id)
        {
            return repositoryBase.GetById(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return repositoryBase.GetAll();
        }
        public void Dispose()
        {
            repositoryBase.Dispose();
        }
    }
}