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

        }
        [TestMethod]
        [TestTraits(Trait.DateTimeTest)]
        public void EndOfDateExtensionTest()
        {

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

        }

    }
}
