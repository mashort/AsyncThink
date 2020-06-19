using System;
using System.Diagnostics;

namespace async_think
{
    public static class Utilities
    {
        public static string GetFormattedElapsedTime(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;
            
            return string.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds / 10);
        }
    }
}
