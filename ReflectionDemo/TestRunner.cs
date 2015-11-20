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
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
