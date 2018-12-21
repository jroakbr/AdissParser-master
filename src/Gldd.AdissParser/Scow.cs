using System;

namespace Gldd.AdissParser
{
    public abstract class Scow
    {
        public Scow(string name, UllageTable ullageTable)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UllageTable = ullageTable ?? throw new ArgumentNullException(nameof(ullageTable));
        }

        public string Name { get; }

        public UllageTable UllageTable { get; }
    }
}
