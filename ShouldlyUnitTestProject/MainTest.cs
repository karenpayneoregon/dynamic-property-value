using BaseLibrary;
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
        /// This test assumes case is not important so we use an overload of ShouldBe to ignore case.
        /// See also <see cref="PropertyNameTest"/> which gives good reason not to use ignore case
        /// unless there are property names such as firstname then you are rightful in slapping that developer ¯\\_(ツ)_/¯
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

        /// <summary>
        /// Test with a property name not in <see cref="Person"/> class
        /// </summary>
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
        [TestTraits(Trait.PersonClass)]
        public void PersonEqualsTest()
        {
            Person mainPerson = SinglePerson;
            Person otherPerson = SinglePerson;

            Assert.IsTrue(mainPerson.IsDeepEqual(otherPerson));

            otherPerson.Id = 5;
            Assert.IsFalse(mainPerson.IsDeepEqual(otherPerson));

            otherPerson.FirstName = "Jim";
            //mainPerson.WithDeepEqual(otherPerson).SkipDefault<Person>().IgnoreSourceProperty(x => x.Id).Assert();

            var comparison = new ComparisonBuilder()
                .IgnoreProperty<Person>(x => x.Id)
                .Create();

            DeepAssert.AreNotEqual(mainPerson, otherPerson, comparison);

            otherPerson.Id = mainPerson.Id;
            otherPerson.FirstName = mainPerson.FirstName;

            Assert.IsTrue(mainPerson.IsDeepEqual(otherPerson));



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
            // property name does not exist
            Assert.IsFalse(SinglePerson.IsValidProperty("FirstName11"));

            // property name does exist case sensitive
            Assert.IsTrue(SinglePerson.IsValidProperty("FirstName"));

            // property name does not exists, casing
            Assert.IsFalse(SinglePerson.IsValidProperty("firstName"));

            // property name does exists, casing ignored
            Assert.IsTrue(SinglePerson.IsValidPropertyIgnoreCase("firstname"));
            
        }

        [TestMethod]
        [TestTraits(Trait.ValidatePropertyNameExtensions)]
        public void GetPropertyValueStaticTest()
        {
            DateTime now = Now;
            int min = now.GetPropValue<int>("TimeOfDay.Minutes");
            int hrs = now.GetPropValue<int>("TimeOfDay.Hours");

            Console.WriteLine($"Hour: {hrs} minutes: {min}");
        }

        /// <summary>
        /// Mock DateTime
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.MockDateTime)]
        public void ClockMocked()
        {

            Clock.Set(() => new DateTime(Now.Year, 6, 14, 13, 23, 0));

            // timely pause for validation
            Task.Delay(2000).Wait();
            var now = Clock.UtcNow;

            Assert.AreEqual(now, new DateTime(Now.Year, 6, 14, 13, 23, 0));

            int min = now.GetPropValue<int>("TimeOfDay.Minutes");
            int hrs = now.GetPropValue<int>("TimeOfDay.Hours");
            
            Assert.AreEqual(now.Hour, hrs);
            Assert.AreEqual(now.Minute, min);

        }
    }
}
