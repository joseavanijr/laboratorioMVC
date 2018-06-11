using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using AtendimentoHospitalar.Contexto;

namespace AtendimentoHospitalar.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        public readonly AtendimentoHospitalarContexto Db = new AtendimentoHospitalarContexto();

        public void Add(TEntity obj)
        {
            try
            {
                Db.Set<TEntity>().Add(obj);
                Db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }

        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(GetById(id));
        }

        public TEntity GetById(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllReadOnly()
        {
            return Db.Set<TEntity>().AsNoTracking();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}