using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
