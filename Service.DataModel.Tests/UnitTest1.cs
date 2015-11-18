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
                context.Configuration.ProxyCreationEnabled = false;

                Assert.IsTrue(context.People.Any(x => x.FirstName == "Kim"));

                Assert.IsInstanceOfType(context.People.First(x => x.FirstName == "Kim"), typeof(Teacher));

                var kim = context.People.First(x => x.FirstName == "Kim");
                if (kim is Teacher)
                {
                    Console.WriteLine("Hooray!");
                }
                else
                {
                    Assert.Fail("Kim should be a teacher!");
                }
                

                Assert.IsTrue(context.
                    People.
                    OfType<Teacher>().
                    Any(x => x.FirstName == "Kim"));

                Assert.IsFalse(context.
                    People.
                    OfType<Student>().
                    Any(x => x.FirstName == "Kim"));

            }
        }
    }
}
