using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebCons.Data
{
    public static class SessionHelper
    {
        public static bool HasTransactionAttribute(MethodInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(TransactionAttribute), true);
        }
    }
}
