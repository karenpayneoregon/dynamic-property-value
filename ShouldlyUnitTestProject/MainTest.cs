using System;
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
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_UserNameChangeTest()
        {
            string expectedValue = "Anne";
            
            var setting = SingleSetting();
            setting.SetValue("UserName", "Anne");
            
            setting.UserName.ShouldBe(expectedValue);
            
            
        }
        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_ContactIdentifierChangeTest()
        {
            var expectedValue = 2;
            var setting = SingleSetting();
            setting.SetValue("ContactIdentifier", 2);
            setting.ContactIdentifier.ShouldBe(expectedValue);
        }

        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_MemberTypeChangeTest()
        {
            var expectedValue = MemberType.Bronze;
            var setting = SingleSetting();
            setting.SetValue("MemberType", MemberType.Bronze);
            setting.MemberType.ShouldBe(expectedValue);
        }

        [TestMethod]
        [TestTraits(Trait.SettingsClass)]
        public void Settings_ActiveChangeTest()
        {
            var setting = SingleSetting();
            setting.SetValue("Active", true);
            setting.Active.ShouldBe(true);
        }

        [TestMethod]
        public void Settings_JoinedChangeTest()
        {
            var expectedValue = new DateTime(Now.Year, Now.Month, Now.Day -1);

            var setting = SingleSetting();
            setting.Joined = new DateTime(Now.Year, Now.Month, Now.Day - 1);
            setting.SetValue("Joined", new DateTime(Now.Year, Now.Month, Now.Day - 1));
            setting.Joined.ShouldBe(expectedValue);
            
        }
    }
}
