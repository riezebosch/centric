using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentricDemo.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void VoorbeeldMetNUnit()
        {
            string name = "marc";

            var validator = new Validator();

            var result = validator.IsValidName(name);

            Assert.That(result, Is.False);
        }
    }
}
