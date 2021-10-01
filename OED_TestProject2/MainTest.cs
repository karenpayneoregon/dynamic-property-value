using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaseLibrary.Classes;
using BaseLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OED_TestProject2.Base;
using OED_TestProject2.Classes;
using static System.DateTime;

namespace OED_TestProject2
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Validate <see cref="DateTimeHelpers.MonthNames"/>
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.DateTimeTest)]
        public void SequenceEquals()
        {
            // arrange
            List<string> expected = new ()
            {
                "January", "February", "March", "April", "May", "June", "July", 
                "August", "September", "October", "November", "December"
            };

            // act
            List<string> monthNames = DateTimeHelpers.MonthNames();

            // assert
            CollectionAssert.AreEqual(monthNames, expected);
        }
        [TestMethod]
        [TestTraits(Trait.DateTimeTest)]
        public void EndOfDateExtensionTest()
        {
            // arrange
            Clock.Set(() => new DateTime(Now.Year, Now.Month, Now.Day, 23, 23, 59,999));
            Task.Delay(1000).Wait();

            var expected = new DateTime(Now.Year, Now.Month, Now.Day, 23, 23, 59,999);

            // act
            var now = Clock.UtcNow;

            // assert
            Assert.IsTrue(DateTime.Compare(now, expected) == 0);

            Clock.Reset();
            Clock.Set(() => new DateTime(Now.Year, Now.Month, Now.Day, 23, 23, 59, 0));

            now = Clock.UtcNow;
            Assert.IsTrue(DateTime.Compare(now, expected) == -1);

            var areEqual = now == expected;
            Assert.IsFalse(areEqual);

        }

        /// <summary>
        /// Test a Switch expression
        ///
        /// - Customer and Order are known in the switch
        /// - Contact is not known which throws a <see cref="InvalidEnumArgumentException"/>
        ///   which is caught with <see cref="Assert.ThrowsException"/>
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void SwitchCommon()
        {
            var expected = "Customer id: 1 Name: Adams";
            Customer customer = new() { Id = 1, Name = "Adams" };
            Assert.AreEqual(Operations.Common(customer), expected);

            expected = "Order id: 12 Product: Phone";
            Order order = new() { Id = 12, Product = "Phone" };
            Assert.AreEqual(Operations.Common(order), expected);

            Contact contact = new() { Id = 45, FirstName = "Jim", LastName = "Smith" };
            Assert.ThrowsException<InvalidEnumArgumentException>(() => Operations.Common(contact));

        }

    }
}
