using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace WebCons.Data
{
    public interface ISessionManager
    {
        ISession OpenSession();
        void Commit();
        void RollBack();
        void BeginTransaction();
        ITransaction Transaction { get; set; }
    }
}
