using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Cruisenet.Audit.Mit.Web.Utility;
using WebCons.WebUI;
using WebCons.WebUI.Utils;

namespace WebCons
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        private WindsorContainer container;
    
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //  WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));

        }

        protected void Session_Start(object sender, EventArgs e)
        {

            HttpContext.Current.Session.Add(Costanti.NOME_OGGETTO_SESSIONE_DATI, new SessionData());
            SessionData sessionData = SessionUtil.GetSessionObject_DATA(System.Web.HttpContext.Current);
        }

        public IWindsorContainer Container
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (container == null)
                    createAuditContainer();
                return container;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void createAuditContainer()
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            container.AddFacility<PersistenceFacility>();

            container.Install(
                new RepositoriesWindsorInstaller(),
                new ControllersWindsorInstaller());
           
        }
    }
}