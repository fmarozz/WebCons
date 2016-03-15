using NHibernate;

namespace WebCons.Data
{
    public class SessionManager : ISessionManager
    {
        private readonly ISessionFactory sessionFactory;
        private ISession session;
        private ITransaction transaction;

        public SessionManager(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            session = sessionFactory.OpenSession();
        }

        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
            Transaction = session.Transaction;
        }

        public ITransaction Transaction { get; set; }

        public ISession OpenSession()
        {
            return session;
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            finally
            {
                transaction.Dispose();

                //session.Flush();
            }
        }

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        public void RollBack()
        {
            if (transaction != null)
                try
                {
                    transaction.Rollback();
                }
                finally
                {
                    transaction.Dispose();
                    session.Clear();
                    //session = sessionFactory.OpenSession();
                    //Transaction = session.Transaction;
                }
        }
    }
}


