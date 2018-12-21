namespace Gldd.AdissParser
{
    public struct UllageRecord
    {
        public UllageRecord(double height, double volume) : this()
        {
            Height = height;
            Volume = volume;
        }

        public double Height { get; }

        public double Volume { get; }
    }
}
