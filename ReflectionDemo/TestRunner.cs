using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionDemo
{
    public class TestRunner
    {
        public bool Execute(System.Reflection.MethodInfo method)
        {
            var instance = Activator.CreateInstance(method.DeclaringType);
            var expected = method
                .GetCustomAttributes(typeof(ExpectedExceptionAttribute), true)
                .Cast<ExpectedExceptionAttribute>();

            try
            {
                method.Invoke(instance, new object[0]);
                return !expected.Any();
            }
            catch (Exception e)
            {
                return expected
                    .Any(a => e.InnerException.GetType() == a.ExceptionType);
            }
        }
    }
}
