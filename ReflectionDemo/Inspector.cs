using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionDemo
{
    public class Inspector
    {
        public IEnumerable<MethodInfo> GetMethods(Type type)
        {
            return type
                .GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(TestMethodAttribute)).Any());
        }
    }
}
