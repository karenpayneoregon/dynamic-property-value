using System;
using System.Reflection;
using BaseLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using ShouldlyUnitTestProject.Base;
using static System.DateTime;

namespace ShouldlyUnitTestProject
{
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
            string expectedValue = "Anne";
            
            var setting = SingleSetting();
            setting.SetValue("UserName", "Anne");
            
            setting.UserName.ShouldBe(expectedValue);
            
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
            var expectedValue = 2;
            var setting = SingleSetting();
            setting.SetValue("ContactIdentifier", 2);
            setting.ContactIdentifier.ShouldBe(expectedValue);
        }

        /// <summary>
        /// <see cref="SingleSetting"/> MemberType (Enum) is set to Gold, change to Bronze and
        /// validate with ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_MemberTypeChangeTest()
        {
            var expectedValue = MemberType.Bronze;
            var setting = SingleSetting();
            setting.SetValue("MemberType", MemberType.Bronze);
            setting.MemberType.ShouldBe(expectedValue);
        }

        /// <summary>
        /// <see cref="SingleSetting"/> Active (bool) is set to false, change to true
        /// and validate using ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_ActiveChangeTest()
        {
            var setting = SingleSetting();
            setting.SetValue("Active", true);
            setting.Active.ShouldBe(true);
        }

        /// <summary>
        ///  <see cref="SingleSetting"/> Joined (DateTime) is set to today, change to yesterday
        /// and validate with ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_JoinedChangeTest()
        {
            var expectedValue = new DateTime(Now.Year, Now.Month, Now.Day -1);

            var setting = SingleSetting();
            setting.Joined = new DateTime(Now.Year, Now.Month, Now.Day - 1);
            setting.SetValue("Joined", new DateTime(Now.Year, Now.Month, Now.Day - 1));
            setting.Joined.ShouldBe(expectedValue);
            
        }

        /// <summary>
        /// <see cref="SinglePerson"/> FirstName (string) is set to Bob, change to Tim and
        /// validate with ShouldBe
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_FirstNameCheck()
        {
            var expectedValue = "Tim";

            var person = SinglePerson;
            person.SetValue("FirstName","Tim");
            person.FirstName.ShouldBe(expectedValue);
        }

        /// <summary>
        /// A full test needs case sensitivity
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_FirstNameCheckCaseInvalid()
        {
            var expectedValue = "tim";

            var person = SinglePerson;
            person.SetValue("FirstName", "Tim");
            person.FirstName.ShouldNotBe(expectedValue);
        }

        /// <summary>
        /// This test assumes case is not important so we use an overload of ShouldBe to ignore case
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_FirstNameCheckIgnoreCase()
        {
            var expectedValue = "tim";
            var person = SinglePerson;

            person.SetValue("FirstName", "Tim");
            person.FirstName.ShouldBe(expectedValue, StringCompareShould.IgnoreCase);
            
        }

        [TestMethod]
        [TestTraits(Trait.PersonClass)]
        public void Person_BrokenUnknownProperty()
        {
            var expectedValue = "tim";
            var person = SinglePerson;

            person.SetValue("SomePropertyDoesNotExists", "Tim");
            person.FirstName.ShouldNotBe(expectedValue);

        }

        [TestMethod]
        [TestTraits(Trait.ValidatePropertyNameExtensions)]
        public void PropertyNameTest()
        {
            // property name does not exist
            Assert.IsFalse(SinglePerson.IsValidProperty("FirstName11"));

            // property name does exist case sensitive
            Assert.IsTrue(SinglePerson.IsValidProperty("FirstName"));

            // property name does not exists, casing
            Assert.IsFalse(SinglePerson.IsValidProperty("firstName"));

            // property name does exists, casing ignored
            Assert.IsTrue(SinglePerson.IsValidPropertyIgnoreCase("firstname"));
            
        }


    }
}
