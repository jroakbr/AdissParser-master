using System;

namespace Gldd.AdissParser
{
    public class ScowSeries
    {
        public ScowSeries(int name, UllageTable ullageTable)
        {
            Name = name;
            UllageTable = ullageTable;
        }

        public int Name { get; }

        public UllageTable UllageTable { get; }

        public static readonly ScowSeries _60;

        public static readonly ScowSeries _500;

        public static readonly ScowSeries _600;

        public static readonly ScowSeries _700;

        static ScowSeries()
        {
            _60 = new ScowSeries(60, GetScowSeries60UllageTable());
            _500 = new ScowSeries(500, GetScowSeries500UllageTable());
            _600 = new ScowSeries(600, GetScowSeries600UllageTable());
            _700 = new ScowSeries(700, GetScowSeries700UllageTable());
        }

        private static UllageTable GetScowSeries60UllageTable()
        {
            return new UllageTable(new[]
            {
                new UllageRecord(4.07, 0),
                new UllageRecord(4.5, 97),
                new UllageRecord(5, 228),
                new UllageRecord(5.5, 360),
                new UllageRecord(6, 494),
                new UllageRecord(6.5, 629),
                new UllageRecord(7, 765),
                new UllageRecord(7.5, 901),
                new UllageRecord(8, 1038),
                new UllageRecord(8.5, 1177),
                new UllageRecord(9, 1317),
                new UllageRecord(9.5, 1458),
                new UllageRecord(10, 1599),
                new UllageRecord(10.5, 1741),
                new UllageRecord(11, 1885),
                new UllageRecord(11.5, 2029),
                new UllageRecord(12, 2175),
                new UllageRecord(12.5, 2321),
                new UllageRecord(13, 2469),
                new UllageRecord(13.5, 2618),
                new UllageRecord(14, 2768),
                new UllageRecord(14.5, 2919),
                new UllageRecord(15, 3070),
                new UllageRecord(15.5, 3223),
                new UllageRecord(16, 3377),
                new UllageRecord(16.5, 3531),
                new UllageRecord(17, 3686),
                new UllageRecord(17.5, 3842),
                new UllageRecord(18, 3999),
                new UllageRecord(18.5, 4157),
                new UllageRecord(19, 4315),
                new UllageRecord(19.5, 4474),
                new UllageRecord(20, 4633),
                new UllageRecord(20.5, 4793),
                new UllageRecord(21, 4953),
                new UllageRecord(21.5, 5114),
                new UllageRecord(22, 5274),
                new UllageRecord(22.5, 5435),
                new UllageRecord(22.76, 5519),
            });
        }

        private static UllageTable GetScowSeries500UllageTable()
        {
            return new UllageTable(new[]
            {
                new UllageRecord(4.21, 0),
                new UllageRecord(4.5, 80),
                new UllageRecord(5, 221),
                new UllageRecord(5.5, 363),
                new UllageRecord(6, 507),
                new UllageRecord(6.5, 651),
                new UllageRecord(7, 797),
                new UllageRecord(7.5, 945),
                new UllageRecord(8, 1093),
                new UllageRecord(8.5, 1242),
                new UllageRecord(9, 1392),
                new UllageRecord(9.5, 1543),
                new UllageRecord(10, 1695),
                new UllageRecord(10.5, 1848),
                new UllageRecord(11, 2003),
                new UllageRecord(11.5, 2159),
                new UllageRecord(12, 2316),
                new UllageRecord(12.5, 2473),
                new UllageRecord(13, 2632),
                new UllageRecord(13.5, 2792),
                new UllageRecord(14, 2952),
                new UllageRecord(14.5, 3114),
                new UllageRecord(15, 3277),
                new UllageRecord(15.5, 3440),
                new UllageRecord(16, 3604),
                new UllageRecord(16.5, 3769),
                new UllageRecord(17, 3935),
                new UllageRecord(17.5, 4102),
                new UllageRecord(18, 4269),
                new UllageRecord(18.5, 4435),
                new UllageRecord(19, 4603),
                new UllageRecord(19.5, 4770),
            });
        }

        private static UllageTable GetScowSeries600UllageTable()
        {
            return new UllageTable(new[]
            {
                new UllageRecord(4.37, 0),
                new UllageRecord(4.5, 33),
                new UllageRecord(5, 161),
                new UllageRecord(5.5, 291),
                new UllageRecord(6, 421),
                new UllageRecord(6.5, 551),
                new UllageRecord(7, 682),
                new UllageRecord(7.5, 813),
                new UllageRecord(8, 943),
                new UllageRecord(8.5, 1078),
                new UllageRecord(9, 1216),
                new UllageRecord(9.5, 1353),
                new UllageRecord(10, 1491),
                new UllageRecord(10.5, 1629),
                new UllageRecord(11, 1767),
                new UllageRecord(11.5, 1905),
                new UllageRecord(12, 2045),
                new UllageRecord(12.5, 2186),
                new UllageRecord(13, 2327),
                new UllageRecord(13.5, 2468),
                new UllageRecord(14, 2612),
                new UllageRecord(14.5, 2756),
                new UllageRecord(15, 2900),
                new UllageRecord(15.5, 3050),
                new UllageRecord(16, 3199),
                new UllageRecord(16.5, 3349),
                new UllageRecord(17, 3498),
                new UllageRecord(17.5, 3648),
                new UllageRecord(18, 3798),
                new UllageRecord(18.5, 3949),
                new UllageRecord(19, 4100),
                new UllageRecord(19.5, 4252),
                new UllageRecord(20, 4404),
                new UllageRecord(20.5, 4555),
                new UllageRecord(20.75, 4631),
            });
        }

        private static UllageTable GetScowSeries700UllageTable()
        {
            return new UllageTable(new[]
            {
                new UllageRecord(4.16, 0),
                new UllageRecord(4.5, 94),
                new UllageRecord(5, 235),
                new UllageRecord(5.5, 377),
                new UllageRecord(6, 520),
                new UllageRecord(6.5, 665),
                new UllageRecord(7, 811),
                new UllageRecord(7.5, 958),
                new UllageRecord(8, 1106),
                new UllageRecord(8.5, 1255),
                new UllageRecord(9, 1405),
                new UllageRecord(9.5, 1557),
                new UllageRecord(10, 1709),
                new UllageRecord(10.5, 1862),
                new UllageRecord(11, 2017),
                new UllageRecord(11.5, 2173),
                new UllageRecord(12, 2329),
                new UllageRecord(12.5, 2487),
                new UllageRecord(13, 2646),
                new UllageRecord(13.5, 2805),
                new UllageRecord(14, 2966),
                new UllageRecord(14.5, 3127),
                new UllageRecord(15, 3289),
                new UllageRecord(15.5, 3452),
                new UllageRecord(16, 3616),
                new UllageRecord(16.5, 3781),
                new UllageRecord(17, 3947),
                new UllageRecord(17.5, 4113),
                new UllageRecord(18, 4280),
                new UllageRecord(18.5, 4446),
                new UllageRecord(19, 4613),
                new UllageRecord(19.5, 4781),
            });
        }
    }
}
