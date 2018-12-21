using System;

namespace Gldd.AdissParser
{
    public class DisposalArea
    {
        public DisposalArea(string name, Polygon2D polygon2D)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Polygon2D = polygon2D ?? throw new ArgumentNullException(nameof(polygon2D));
        }

        public string Name { get; }

        public Polygon2D Polygon2D { get; }
    }
}