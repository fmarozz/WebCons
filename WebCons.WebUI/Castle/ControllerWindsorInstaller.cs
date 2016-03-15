using System.Web.Configuration;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Cruisenet.Mvc;
using WebCons.WebUI.Controllers;

public class ControllersWindsorInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            AllTypes.Of<IController>()
                .FromAssembly(typeof (MainController).Assembly).LifestyleTransient()
                .ConfigureFor<IController>(
                    x =>
                        x.Named(x.Implementation.Name.Replace("Controller", string.Empty))),

            Component.For<IActionInvoker>()
                .ImplementedBy<WindsorActionInvoker>());
    }
}