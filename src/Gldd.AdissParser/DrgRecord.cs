using System;

namespace Gldd.AdissParser
{
    public class DrgRecord
    {
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public DateTime DateTime => Date.Add(Time);

        public double BucketX { get; set; }

        public double BucketY { get; set; }

        public double BucketStation { get; set; }

        public double BucketDepth { get; set; }
    }
}
