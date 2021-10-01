using System;
using System.Reflection.PortableExecutable;
using BaseLibrary.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OED_TestProject1.Base;
using OED_TestProject1.Classes;
using static System.DateTime;

namespace OED_TestProject1
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.WorkingWithDates)]
        public void TestMethod1()
        {

            Person person = BasePerson;
            Assert.AreEqual(person.Age, "65 years 0 months 6 days");

        }
        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void TestMethod2()
        {

            Clock.Set(() => new DateTime(1956, 9, 24));
            Person person = BasePerson;
            Assert.AreEqual(person.Age, "65 years 0 months 6 days");

            

        }
    }
}
