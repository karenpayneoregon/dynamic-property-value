using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using BaseLibrary;
using BaseLibrary.Classes;
using BaseLibrary.Extensions;
using DeepEqual;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using ShouldlyUnitTestProject.Base;
using ShouldlyUnitTestProject.Classes;
using static System.DateTime;




namespace ShouldlyUnitTestProject
{
    /// <summary>
    /// Test <see cref="Extensions.SetValue()"/>
    /// </summary>
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Test setting a string value
        /// 
        /// <see cref="SingleSetting"/> UserName is set to Karen, change UserName to Anne
        /// and validate using ShouldBe
        /// 
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_UserNameChangeTest()
        {

            
        }

        /// <summary>
        /// Test setting an int value
        /// 
        /// <see cref="SingleSetting"/> ContactIdentifier has a value of 1,change ContactIdentifier
        /// to 2 and validate with ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_ContactIdentifierChangeTest()
        {

        }

        /// <summary>
        /// <see cref="SingleSetting"/> MemberType (Enum) is set to Gold, change to Bronze and
        /// validate with ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_MemberTypeChangeTest()
        {

        }

        /// <summary>
        /// <see cref="SingleSetting"/> Active (bool) is set to false, change to true
        /// and validate using ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_ActiveChangeTest()
        {

        }

        /// <summary>
        ///  <see cref="SingleSetting"/> Joined (DateTime) is set to today, change to yesterday
        /// and validate with ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_JoinedChangeTest()
        {

            
        }

        /// <summary>
        /// <see cref="SinglePerson"/> FirstName (string) is set to Bob, change to Tim and
        /// validate with ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_FirstNameCheck()
        {

        }

        /// <summary>
        /// A full test needs case sensitivity
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_FirstNameCheckCaseInvalid()
        {
          
        }

        /// <summary>
        /// This test assumes case is not important so we use an overload of ShouldBe to ignore case.
        /// See also <see cref="PropertyNameTest"/> which gives good reason not to use ignore case
        /// unless there are property names such as firstname then you are rightful in slapping that developer ¯\\_(ツ)_/¯
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_FirstNameCheckIgnoreCase()
        {

            
        }

        /// <summary>
        /// Test with a property name not in <see cref="Person"/> class
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_BrokenUnknownProperty()
        {

        }

        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void PersonEqualsTest()
        {
    
        }


        /// <summary>
        /// Extensions test - not using fluent assertions
        ///
        /// Note <see cref="Extensions.IsValidPropertyIgnoreCase()"/>
        /// It's here to determine if a property exists in a class using
        /// a string value yet if someone say had FirstName and firstName
        /// properties we have a conflict. Now if someone did code these
        /// two properties feel free to slap them.
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.ValidatePropertyNameExtensions)]
        public void PropertyNameTest()
        {
            
        }

        [TestMethod]
        [TestTraits(Trait.ValidatePropertyNameExtensions)]
        public void GetPropertyValueStaticTest()
        {

        }

        /// <summary>
        /// Mock DateTime
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.MockDateTime)]
        public void ClockMocked()
        {

        }
    }
}
