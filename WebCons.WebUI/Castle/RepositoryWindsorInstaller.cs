  using Castle.Core;
  using Castle.MicroKernel.Registration;
  using Castle.MicroKernel.SubSystems.Configuration;
  using Castle.Windsor;
  using WebCons.Data;

namespace WebCons.WebUI
{
    public class RepositoriesWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
            container.Register(
                Component.For(typeof (IRepository<>))
                    .ImplementedBy(typeof (Repository<>)).LifestylePerWebRequest()
                ,
                //Unitofwork interceptor
                Component.For<TransactionInterceptor>().LifeStyle.Transient,
                AllTypes.FromAssemblyContaining<SessionManager>()
                    .IncludeNonPublicTypes()
                    .Where(x => x.Name.EndsWith("Repository")).LifestylePerWebRequest()

                    .WithService.AllInterfaces());
        }

        private void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            //Intercept all methods of all repositories.
            //   if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Services.First()))
            //   {
            //       handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
            //   }

            //Intercept all methods of classes those have at least one method that has UnitOfWork attribute.
            foreach (var method in handler.ComponentModel.Implementation.GetMethods())
            {
                if (SessionHelper.HasTransactionAttribute(method))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof (TransactionInterceptor)));
                    return;
                }
            }
        }
    }
}