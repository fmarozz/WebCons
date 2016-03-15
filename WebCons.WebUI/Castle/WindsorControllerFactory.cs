// Type: MvcContrib.Castle.WindsorControllerFactory
// Assembly: MvcContrib.Castle, Version=2.0.0.99, Culture=neutral, PublicKeyToken=null
// Assembly location: D:\Rfi-Audit-Bds\Cruisenet.Audit.Web.Tests\bin\Debug\MvcContrib.Castle.dll

namespace Cruisenet.Audit.Mit.Web.Utility
{
    using Castle.Windsor;
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public override void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }

            this.container.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            var controller = this.container.Resolve(controllerType) as Controller;

            if (controller != null)
            {
                controller.ActionInvoker = this.container.Resolve<IActionInvoker>(this.container);
            }

            return controller;
        }
    }
}
