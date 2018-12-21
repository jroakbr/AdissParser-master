using System.Collections.Generic;
using System.Linq;

namespace Gldd.AdissParser
{
    public class Polygon2D
    {
        private readonly List<Point2D> vertices;

        public Polygon2D(IEnumerable<Point2D> vertices)
        {
            this.vertices = new List<Point2D>(vertices);
        }

        public bool DoesBound(Point2D point2D)
        {
            //https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
            bool result = false;
            int j = vertices.Count() - 1;
            for (int i = 0; i < vertices.Count(); i++)
            {
                if (vertices[i].Y < point2D.Y && vertices[j].Y >= point2D.Y || vertices[j].Y < point2D.Y && vertices[i].Y >= point2D.Y)
                {
                    if (vertices[i].X + (point2D.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) * (vertices[j].X - vertices[i].X) < point2D.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}
