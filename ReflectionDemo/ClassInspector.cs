using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionDemo
{
    public class ClassInspector
    {
        private Type type;

        public ClassInspector(Type type)
        {
            this.type = type;
        }
        public IEnumerable<MethodInfo> GetMethods()
        {
            return type
                .GetMethods()
                .Where(m => m.GetCustomAttributes<TestMethodAttribute>().Any());
        }

        public MethodInfo GetClassInitialize()
        {
            return type
                .GetMethods()
                .SingleOrDefault(m => m.GetCustomAttributes<ClassInitializeAttribute>().Any());
        }

        public MethodInfo GetTestInitialize()
        {
            return type
                .GetMethods()
                .SingleOrDefault(m => m.GetCustomAttributes<TestInitializeAttribute>().Any());
        }

        public MethodInfo GetTestCleanUp()
        {
            return type
                .GetMethods()
                .SingleOrDefault(m => m.GetCustomAttributes<TestCleanupAttribute>().Any());
        }

        public MethodInfo GetClassCleanUp()
        {
            return type
                .GetMethods()
                .SingleOrDefault(m => m.GetCustomAttributes<ClassCleanupAttribute>().Any());
        }
    }
}