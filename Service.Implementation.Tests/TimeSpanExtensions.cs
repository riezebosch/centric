using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation.Tests
{
    static class TimeSpanExtensions
    {
        public static TaskAwaiter GetAwaiter(this TimeSpan t)
        {
            return Task.Delay(t).GetAwaiter();
        }
    }
}
