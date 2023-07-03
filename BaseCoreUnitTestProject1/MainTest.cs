using System;
using System.Collections.Generic;
using BaseCoreUnitTestProject1.Base;
using BaseLibrary.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using static System.DateTime;

namespace BaseCoreUnitTestProject1
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.StringEmptyTest)]
        public void TestMethod1()
        {
            var expected = "Karen";
            string firstName = "karen";

            Assert.AreNotEqual(firstName, expected,
                $"Expected not to equal '{firstName}'");

            firstName = "Karen";
            Assert.AreEqual(firstName, expected);
            Console.WriteLine(DateTime.Now);

        }
        [TestMethod]
        [TestTraits(Trait.DateTimeTest)]
        public void SequenceEquals()
        {
            // arrange
                List<string> expected = new()
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

            // act
            var monthNames  = DateTimeHelpers.MonthNames();

            // assert
            CollectionAssert.AreEqual(monthNames, expected);
        }

        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void MyTestMethod()
        {

        }
    }
}
