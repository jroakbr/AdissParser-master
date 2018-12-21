namespace Gldd.AdissParser
{
    /// <summary>
    /// Rental scow from Marinex.
    /// </summary>
    public class MarinexScow : Scow
    {
        public MarinexScow(string name, UllageTable ullageTable) : base(name, ullageTable) { }

        private static readonly UllageTable _mx2014_15UllageTable = new UllageTable(new[]
        {
            new UllageRecord(4.349, 0),
            new UllageRecord(4.5, 39.4074074074074),
            new UllageRecord(5, 167.308641975309),
            new UllageRecord(5.5, 297.283950617284),
            new UllageRecord(6, 427.259259259259),
            new UllageRecord(6.5, 557.925925925926),
            new UllageRecord(7, 687.901234567901),
            new UllageRecord(7.5, 818.567901234568),
            new UllageRecord(8, 949.925925925926),
            new UllageRecord(8.5, 1084.74074074074),
            new UllageRecord(9, 1221.62962962963),
            new UllageRecord(9.5, 1359.20987654321),
            new UllageRecord(10, 1496.79012345679),
            new UllageRecord(10.5, 1635.06172839506),
            new UllageRecord(11, 1772.64197530864),
            new UllageRecord(11.5, 1910.91358024691),
            new UllageRecord(12, 2051.25925925926),
            new UllageRecord(12.5, 2192.2962962963),
            new UllageRecord(13, 2333.33333333333),
            new UllageRecord(13.5, 2474.37037037037),
            new UllageRecord(14, 2618.17283950617),
            new UllageRecord(14.5, 2762.66666666667),
            new UllageRecord(15, 2906.46913580247),
            new UllageRecord(15.5, 3055.8024691358),
            new UllageRecord(16, 3205.13580246914),
            new UllageRecord(16.5, 3355.16049382716),
            new UllageRecord(17, 3504.49382716049),
            new UllageRecord(17.5, 3654.51851851852),
            new UllageRecord(18, 3804.54320987654),
            new UllageRecord(18.5, 3955.25925925926),
            new UllageRecord(19, 4106.66666666667),
            new UllageRecord(19.5, 4258.07407407407),
            new UllageRecord(20, 4410.17283950617),
            new UllageRecord(20.5, 4561.58024691358),
            new UllageRecord(21, 4713.67901234568),
            new UllageRecord(21.5, 4865.08641975309),
            new UllageRecord(22, 5017.18518518519),
            new UllageRecord(22.5, 5169.97530864198),
            new UllageRecord(23, 5322.76543209877),
            new UllageRecord(23.5, 5475.55555555556),
            new UllageRecord(24, 5628.34567901235),
            new UllageRecord(24.5, 5780.44444444445),
            new UllageRecord(25, 5933.23456790124),
            new UllageRecord(25.5, 6086.02469135802),
        });

        public static readonly MarinexScow MX2014 = new MarinexScow("MX2014", _mx2014_15UllageTable);

        public static readonly MarinexScow MX2015 = new MarinexScow("MX2015", _mx2014_15UllageTable);
    }
}
