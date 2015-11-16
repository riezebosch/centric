using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentricDemo;

namespace CentricDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitCapsNameResultIsTrue()
        {
            // Arrange
            string name = "Marc";
            var validator = new Validator();

            // Act
            bool result = validator.IsValidName(name);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LowerCaseNameResultIsFalse()
        {
            string name = "marc";

            var validator = new Validator();

            var result = validator.IsValidName(name);

            Assert.IsFalse(result);
        }
    }
}
