using System;

namespace Survi.Prevention.Models
{
    public static class Metrics
    {
        public static TimeSpan GetRealForeignKeysTotalTime { get; set; } = new TimeSpan();
        public static TimeSpan GetEntitiyFromDatabase { get; set; } = new TimeSpan();
        public static TimeSpan CreateNew { get; set; } = new TimeSpan();

        public static void Reset()
        {
            GetRealForeignKeysTotalTime = new TimeSpan();
            GetEntitiyFromDatabase = new TimeSpan();
            CreateNew = new TimeSpan();            
        }
    }
}
