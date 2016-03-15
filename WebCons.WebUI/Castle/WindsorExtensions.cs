// Decompiled with JetBrains decompiler
// Type: Cruisenet.Mvc.WindsorExtensions
// Assembly: Cruisenet.Mvc, Version=2.1.0.2312, Culture=neutral, PublicKeyToken=null
// MVID: B9DC442F-E5B7-4203-8A0A-497D41BCEF5F
// Assembly location: D:\Old\Normanet\SharedLibs\Cruisenet.Mvc.dll

using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using System;
using System.Reflection;
using Castle.Core;

namespace Cruisenet.Mvc
{
    internal static class WindsorExtensions
    {
        internal static void InjectProperties(this IKernel kernel, object target)
        {
            Type type = target.GetType();
            foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.CanWrite && kernel.HasComponent(propertyInfo.PropertyType))
                {
                    object obj = kernel.Resolve(propertyInfo.PropertyType);
                    try
                    {
                        propertyInfo.SetValue(target, obj, (object[])null);
                    }
                    catch (Exception ex)
                    {
                        throw new ComponentActivatorException(string.Format("Error setting property {0} on type {1}, See inner exception for more information.", ex, (object)propertyInfo.Name, (object)type.FullName), ex, new ComponentModel());
                    }
                }
            }
        }
    }
}
