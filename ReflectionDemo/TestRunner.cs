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

            try
            {
                method.Invoke(instance, new object[0]);

                return !method
                    .GetCustomAttributes(typeof(ExpectedExceptionAttribute), true)
                    .Any();
            }
            catch (Exception e)
            {
                var expected = method
                    .GetCustomAttributes(typeof(ExpectedExceptionAttribute), true)
                    .Cast<ExpectedExceptionAttribute>();
                
                return expected
                    .Any(a => e.InnerException.GetType() == a.ExceptionType);
            }

            return true;
        }
    }
}
