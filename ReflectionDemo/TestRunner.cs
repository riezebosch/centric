using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionDemo
{
    public class TestRunner
    {
        object instance;

        public TestRunner(Type type)
            : this(Activator.CreateInstance(type))
        {
        }

        public TestRunner(object instance)
        {
            this.instance = instance;
        }
        public bool Execute(MethodInfo method)
        {
            var expected = method
                .GetCustomAttributes<ExpectedExceptionAttribute>();

            try
            {
                method.Invoke(instance, new object[0]);
                return !expected.Any();
            }
            catch (Exception e)
            {
                if (!expected
                    .Any(a => e.InnerException.GetType() == a.ExceptionType))
                {
                    Console.WriteLine(e.InnerException);
                    return false;
                }
            }

            return true;
        }
    }
}
