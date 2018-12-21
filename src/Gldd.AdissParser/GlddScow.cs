using System;

namespace Gldd.AdissParser
{
    public class GlddScow : Scow
    {
        public GlddScow(string name, ScowSeries scowSeries) 
            : base(name, 
                  scowSeries.UllageTable ?? throw new ArgumentNullException(nameof(scowSeries)))
        {
            ScowSeries = scowSeries;
        }

        public ScowSeries ScowSeries { get; }
    }
}
