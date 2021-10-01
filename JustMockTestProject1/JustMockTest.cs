using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.JustMock;

namespace JustMockTestProject1
{
    /// <summary>
    /// Summary description for JustMockTest
    /// </summary>
    [TestClass]
    public class JustMockTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod()
        {
            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void ShouldAssertCustomValueForDateTimeNow()
        {
            var expected = new DateTime(1900, 4, 12);

            // ARRANGE - Here we arrange, when DateTime.Now is called it should return expected DateTime.
            Mock.Arrange(() => DateTime.Now).Returns(expected);

            // ACT
            var now = DateTime.Now;

            // ASSERT
            Assert.AreEqual(expected.Year, now.Year);
            Assert.AreEqual(expected.Month, now.Month);
            Assert.AreEqual(expected.Day, now.Day);

            Console.WriteLine(DateTime.Now);
        }
    }
}
