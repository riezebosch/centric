using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Service.DataModel.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new SchoolEntities())
            {
                foreach (var person in context.People)
                {
                    Console.WriteLine("Name: {0} {1}", person.FirstName, person.LastName);
                }
            }
        }

        [TestMethod]
        public void ControleerDatKimBijDePersonenZit()
        {
            using (var context = new SchoolEntities())
            {
                Assert.IsTrue(context.People.Any(x => x.FirstName == "Kim"));
            }
        }
    }
}
