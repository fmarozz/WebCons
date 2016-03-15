// Decompiled with JetBrains decompiler
// Type: Cruisenet.Mvc.WindsorActionInvoker
// Assembly: Cruisenet.Mvc, Version=2.1.0.2312, Culture=neutral, PublicKeyToken=null
// MVID: B9DC442F-E5B7-4203-8A0A-497D41BCEF5F
// Assembly location: D:\Old\Normanet\SharedLibs\Cruisenet.Mvc.dll

using Castle.MicroKernel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Cruisenet.Mvc
{
    public class WindsorActionInvoker : ControllerActionInvoker
    {
        private readonly IKernel container;

        public WindsorActionInvoker(IKernel container)
        {
            this.container = container;
        }

        internal void InjectDependencies(IList<IActionFilter> filters)
        {
            foreach (object target in (IEnumerable<IActionFilter>)filters)
                WindsorExtensions.InjectProperties(this.container, target);
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(ControllerContext controllerContext, IList<IActionFilter> filters, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
        {
            this.InjectDependencies(filters);
            return base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
        }
    }
}
