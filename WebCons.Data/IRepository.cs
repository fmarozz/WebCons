using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCons.Data
{
    public interface IRepository<T>
    {
        T FindById(int id);
        T FindById(Guid id);
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> FindAll();

    }
}
