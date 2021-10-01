using System;
using System.Reflection.PortableExecutable;
using BaseLibrary.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OED_TestProject1.Base;
using OED_TestProject1.Classes;
using static System.DateTime;


/*
 * Mock System API
 * https://docs.telerik.com/devtools/justmock/getting-started/api-basics/system-api
 */
namespace OED_TestProject1
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// This will fail
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.WorkingWithDates)]
        public void TestMethod1()
        {

        }

        /// <summary>
        /// This will work but we had to add a DateTime property to make this work which is
        /// not the proper way to write a test as Person.CurrentDateTime was added to force
        /// the test to work.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void TestMethod2()
        {


        }


    }
}
