using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShouldlyUnitTestProject.Classes
{
    public static class Clock
    {
        private static Func<DateTime> _utcNow = () 
            => DateTime.UtcNow;

        static AsyncLocal<Func<DateTime>> _override = new();

        public static DateTime UtcNow 
            => (_override.Value ?? _utcNow)();

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
