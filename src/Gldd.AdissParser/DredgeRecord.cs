namespace Gldd.AdissParser
{
    public class DredgeRecord
    {
        public DredgeRecord(double x, double y, double depth, double station)
        {
            X = x;
            Y = y;
            Depth = depth;
            Station = station;
        }

        public double X { get; }

        public double Y { get; }

        public double Depth { get; }

        public double Station { get; }
    }
}