using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
 

namespace WebCons.Data
{
   
        public class Repository<T> : IRepository<T>
        {
            private readonly ISessionManager sessionManager;
            
            public Repository(ISessionManager sessionManager)
            {
                
                this.sessionManager = sessionManager;
            }

            public T FindById(int id)
            {
                return sessionManager.OpenSession().Get<T>(id);
            }

            public T FindById(Guid id)
            {
                return sessionManager.OpenSession().Get<T>(id);
            }

            [Transaction]
            public void Save(T entity)
            {
                sessionManager.OpenSession().Save(entity);

            }
            [Transaction]
            public void Update(T entity)
            {
                sessionManager.OpenSession().Update(entity);
                
            }
            [Transaction]
            public void Delete(T entity)
            {
                sessionManager.OpenSession().Delete(entity);
            }

            public IEnumerable<T> FindAll()
            {
                return sessionManager.OpenSession().Query<T>().ToList();
            }

        
    }

}
