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
            var inspector = new Inspector();
            IEnumerable<MethodInfo> methods = inspector.GetMethods(typeof(TestDemoClass));

            Assert.IsNotNull(methods);
            Assert.AreEqual(2, methods.Count());
        }

        [TestMethod]
        public void TestExecuteOfTestMethod()
        {
            var runner = new TestRunner();
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("MyTestMethod"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteOfFailingTestShouldReturnFalse()
        {
            var runner = new TestRunner();
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("FailingTest"));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ExecuteOfMethodThrowingExpectedExceptionShouldReturnTrue()
        {
            var runner = new TestRunner();
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("ThrowsExpectedException"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExecuteOfMethodNotThrowingExpectedExceptionShouldReturnFalse()
        {
            var runner = new TestRunner();
            bool result = runner.Execute(typeof(TestDemoClass).GetMethod("NotThrowingExpectedException"));

            Assert.IsFalse(result);
        }
    }

    public class TestDemoClass 
    {
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
    }
}
