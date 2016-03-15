 using System.Configuration;
 using Castle.MicroKernel.Facilities;
 using Castle.MicroKernel.Registration;
 using Castle.MicroKernel.Resolvers;
 using NHibernate;
 using WebCons.Data;
 using WebCons.WebUI;

public class PersistenceFacility : AbstractFacility
{
    protected override void Init()
    {
        NhibernateConfiguration.stringaConnessione = ConfigurationManager.AppSettings["connString"];
         
        Kernel.Register(
            Component.For<ILazyComponentLoader>()
                .ImplementedBy<LazyOfTComponentLoader>(),
            Component.For<ISessionFactory>()
                .UsingFactoryMethod<ISessionFactory>(NhibernateConfiguration.CreateSessionFactory),

            Component.For<ISessionManager>().ImplementedBy<SessionManager>().LifestylePerWebRequest());
    }
}