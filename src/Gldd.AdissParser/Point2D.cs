namespace Gldd.AdissParser
{
    public struct Point2D
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }

        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }
}