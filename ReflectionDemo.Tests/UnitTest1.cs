using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionDemo;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ReflectionDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var inspector = new ClassInspector(typeof(TestDemoClass));
            IEnumerable<MethodInfo> methods = inspector.GetMethods();

            Assert.IsNotNull(methods);
            Assert.AreEqual(6, methods.Count());
        }

        [TestMethod]
        public void TestExecuteOfTestMethod()
        {
            var runner = new TestRunner(typeof(TestDemoClass));
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("MyTestMethod"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteOfFailingTestShouldReturnFalse()
        {
            var runner = new TestRunner(typeof(TestDemoClass));
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("FailingTest"));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExecuteOfMethodThrowingExpectedExceptionShouldReturnTrue()
        {
            var runner = new TestRunner(typeof(TestDemoClass));
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("ThrowsExpectedException"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteOfMethodNotThrowingExpectedExceptionShouldReturnFalse()
        {
            var runner = new TestRunner(typeof(TestDemoClass));
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("NotThrowingExpectedException"));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestListAllClassesOfTestAssembly()
        {
            var inspector = new AssemblyInspector(this.GetType().Assembly.Location);
            var classes = inspector.GetClasses();

            Assert.IsTrue(classes.Any(c => c == this.GetType()));
        }

        [TestMethod]
        public void OnlyListTestClassesOfTestAssembly()
        {
            var inspector = new AssemblyInspector(this.GetType().Assembly.Location);
            var classes = inspector.GetClasses();

            Assert.IsFalse(classes.Any(c => c == typeof(NormalClass)));
        }

        [TestMethod]
        public void TestGetTestInitialize()
        {
            var inspector = new ClassInspector(typeof(TestDemoClass));
            MethodInfo m = inspector.GetTestInitialize();

            Assert.IsNotNull(m);
            Assert.AreEqual("TestInit", m.Name);
        }

        [TestMethod]
        public void TestGetTestCleanUp()
        {
            var inspector = new ClassInspector(typeof(TestDemoClass));
            MethodInfo m = inspector.GetTestCleanUp();

            Assert.IsNotNull(m);
            Assert.AreEqual("TestClean", m.Name);
        }

        [TestMethod]
        public void TestGetClassInitialize()
        {
            var inspector = new ClassInspector(typeof(TestDemoClass));
            MethodInfo m = inspector.GetClassInitialize();

            Assert.IsNotNull(m);
            Assert.AreEqual("ClassInit", m.Name);
        }

        [TestMethod]
        public void TestGetClassCleanup()
        {
            var inspector = new ClassInspector(typeof(TestDemoClass));
            MethodInfo m = inspector.GetClassCleanUp();

            Assert.IsNotNull(m);
            Assert.AreEqual("ClassClean", m.Name);
        }

        [TestMethod]
        public void TestRunnerExecuteClassInitializeOnStatic()
        {
            object instance = new TestDemoClass();
            var runner = new TestRunner(instance);
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("ClassInit"));

            Assert.IsTrue(result);
            Assert.IsTrue(TestDemoClass.IsInitialized);
        }

        [TestMethod]
        public void TestRunnerShouldAcceptType()
        {
            var runner = new TestRunner(typeof(TestDemoClass));
        }

        [TestMethod]
        public void TestRunnerShouldRunMultipleTestsOnSameInstance()
        {
            var runner = new TestRunner(typeof(TestDemoClass));
            runner.Execute(typeof(TestDemoClass).GetMethod("MultipleFirst"));
            var result = runner.Execute(typeof(TestDemoClass).GetMethod("MultipleSecond"));
            Assert.IsTrue(result);
        }
    }

    public class TestDemoClass 
    {
        [ClassInitialize]
        public static void ClassInit()
        {
            IsInitialized = true;
        }

        [ClassCleanup]
        public static void ClassClean()
        {
        }


        [TestInitialize]
        public void TestInit()
        {
        }

        [TestCleanup]
        public void TestClean()
        {
        }

        [TestMethod]
        public void MyTestMethod()
        {
        }

        [TestMethod]
        public void FailingTest()
        {
            Assert.Fail("kaboom!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsExpectedException()
        {
            throw new ArgumentNullException();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotThrowingExpectedException()
        {
        }

        int i = 0;
        [TestMethod]
        public void MultipleFirst()
        {
            i++;
        }

        [TestMethod]
        public void MultipleSecond()
        {
            Assert.AreEqual(1, i);
        }

        public static bool IsInitialized { get; private set; }
    }

    public class NormalClass
    {
    }
}
