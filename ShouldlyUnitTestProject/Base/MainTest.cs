using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLibrary;


// ReSharper disable once CheckNamespace - do not change
namespace ShouldlyUnitTestProject
{
    public partial class MainTest
    {

        /// <summary>
        /// Perform initialization before each test runs
        /// </summary>
        /// <returns>Nothing we care about</returns>
        /// <remarks>
        /// For synchronous preparation
        /// * Remove the async modifier
        /// * Remove the line with await Task.Delay(0);
        /// * We can do TestContext.TestName == "TestMethod1" better
        /// </remarks>
        [TestInitialize]
        public async Task Init()
        {
            if (TestContext.TestName == "TestMethod1")
            {
                await Task.Delay(0);
                Console.WriteLine("Called before TestMethod1");
            }
        }
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "TestMethod1")
            {
                
            }
            else
            {
                
            }

        }
        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }

        public Settings SingleSetting() => 
            new()
            {
                UserName = "Karen", 
                MemberType = MemberType.Gold, 
                ContactIdentifier = 1, 
                Active = false, 
                Joined = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)
            };

        public Person SinglePerson => new ()
        {
            Id = 1,
            FirstName = "Bob", 
            LastName = "Gallagher"
        };
    }

}
