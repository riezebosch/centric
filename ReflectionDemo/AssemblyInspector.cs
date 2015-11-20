using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionDemo
{
    public class AssemblyInspector
    {
        private string location;

        public AssemblyInspector(string location)
        {
            this.location = location;
        }
        public IEnumerable<Type> GetClasses()
        {
            return Assembly.LoadFrom(location).GetTypes().Where(t => t.IsClass && t.GetCustomAttributes(typeof(TestClassAttribute), true).Any());
        }
    }
}
