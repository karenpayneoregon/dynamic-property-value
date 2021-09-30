using System;
using System.Threading;

namespace ShouldlyUnitTestProject.Classes
{
    /// <summary>
    /// Responsible for mocking <see cref="DateTime"/> for unit testing
    /// 
    /// Telerik.JustMock does this much better via a service
    ///     Mock.Arrange(() => DateTime.Now).Returns(new DateTime(2021, 7, 12));
    ///     var now = DateTime.Now;
    ///     Assert.AreEqual(2021, now.Year);
    ///     Assert.AreEqual(7, now.Month);
    ///     Assert.AreEqual(12, now.Day);
    /// </summary>
    public static class Clock
    {
        private static Func<DateTime> _utcNow = () 
            => DateTime.UtcNow;

        static AsyncLocal<Func<DateTime>> _override = new();

        /// <summary>
        /// Get mocked <see cref="DateTime"/>
        /// </summary>
        public static DateTime UtcNow 
            => (_override.Value ?? _utcNow)();

        /// <summary>
        /// Set <see cref="DateTime"/>
        /// </summary>
        /// <param name="sender"></param>
        public static void Set(Func<DateTime> sender)
        {
            _override.Value = sender;
        }

        public static void Reset()
        {
            _override.Value = null;
        }
    }
}
