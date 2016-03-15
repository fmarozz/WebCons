using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Proxy.DynamicProxy;

namespace WebCons.Data
{
    using IInterceptor = Castle.DynamicProxy.IInterceptor;
        public class TransactionInterceptor : IInterceptor
    {
        private readonly ISessionManager sessionManager;
        private ISession session;
        private readonly ISessionFactory sessionFactory;


        /// <summary>
        /// Creates a new NhUnitOfWorkInterceptor object.
        /// </summary>
        /// <param name="sessionFactory">Nhibernate session factory.</param>
        public TransactionInterceptor(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
            session=sessionManager.OpenSession();
        }

        /// <summary>
        /// Intercepts a method.
        /// </summary>
        /// <param name="invocation">Method invocation arguments</param>
        public void Intercept(IInvocation invocation)
        {
            if (SessionHelper.HasTransactionAttribute(invocation.MethodInvocationTarget)==false)
            {
                invocation.Proceed();
            }
            else
            
            {
               
               
                 
                //If there is a running transaction, just run the method
                if (sessionManager.Transaction!=null && sessionManager.Transaction.IsActive)
                {
                    invocation.Proceed();
                    return;
                }
               
             

                sessionManager.BeginTransaction();

                try
                {
                    invocation.Proceed();
                    if (sessionManager.Transaction.IsActive)
                   sessionManager.Commit();   
                   
                   
                }
                catch
                {
                    try
                    {
                        if (sessionManager.Transaction.IsActive)
                        sessionManager.RollBack();
                       
                    }
                    catch
                    {

                    }

                    throw;
                }
            }
        }
    }
}
