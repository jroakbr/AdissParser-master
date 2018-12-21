using System.Collections.Generic;

namespace Gldd.AdissParser
{
    public class CharlestonDeepening2Service : ICharlestonDeepening2Service
    {
        private static readonly DisposalArea _beneficialReef1;
        private static readonly DisposalArea _beneficialReef2;
        private static readonly DisposalArea _beneficialReef3;
        private static readonly DisposalArea _beneficialReef4;
        private static readonly DisposalArea _beneficialReef5;
        private static readonly DisposalArea _beneficialReef6;

        private static readonly DisposalArea _mitigationReefJ;
        private static readonly DisposalArea _mitigationReefS;
        private static readonly DisposalArea _dumpsite7;


        private static readonly DisposalArea _odmdsEast;
        private static readonly DisposalArea _odmdsSouth;
        private static readonly DisposalArea _odmdsWest;
        private static readonly Polygon2D _berm;

        private readonly Polygon2D _channel;

        public CharlestonDeepening2Service()
        {
            _channel = GetChannel();
        }

        static CharlestonDeepening2Service()
        {
            _beneficialReef1 = GetBeneficialReef1();
            _beneficialReef2 = GetBeneficialReef2();
            _beneficialReef3 = GetBeneficialReef3();
            _beneficialReef4 = GetBeneficialReef4();
            _beneficialReef5 = GetBeneficialReef5();
            _beneficialReef6 = GetBeneficialReef6();

            _mitigationReefJ = GetMitigationReefJ();
            _mitigationReefS = GetMitigationReefS();
            _dumpsite7 = GetDumpSite7();

            _odmdsEast = GetOdmds("East");
            _odmdsSouth = GetOdmds("South");
            _odmdsWest = GetOdmds("West");
            _berm = GetBerm();
        }

        public static IEnumerable<DisposalArea> GetDisposalAreas() => new[]
        {
            _beneficialReef1,
            _beneficialReef2,
            _beneficialReef3,
            _beneficialReef4,
            _beneficialReef5,
            _beneficialReef6,
            _mitigationReefJ,
            _mitigationReefS,
            _odmdsEast,
            _odmdsSouth,
            _odmdsWest,
            _dumpsite7,
            
        };

        private static DisposalArea GetBeneficialReef1()
        {
            return new DisposalArea(
                "Beneficial Reef 1",
                new Polygon2D(new[]
                {
                    new Point2D(2394831.48255347, 302963.473372597),
                    new Point2D(2394533.30912265, 302930.418794171),
                    new Point2D(2394500.25454422, 303228.592224988),
                    new Point2D(2397183.81542158, 303526.083430817),
                    new Point2D(2397216.87, 303227.91),
                    new Point2D(2396918.69656918, 303194.855421575),
                    new Point2D(2396951.75114761, 302896.681990758),
                    new Point2D(2394864.53713189, 302665.299941779),
                }));
        }

        private static DisposalArea GetBeneficialReef2()
        {
            return new DisposalArea(
                "Beneficial Reef 2",
                new Polygon2D(new[]
                {
                    new Point2D(2397813.21439247, 303294.026784088),
                    new Point2D(2397780.15774048, 303592.199985028),
                    new Point2D(2399867.37014707, 303823.596548952),
                    new Point2D(2399900.42679906, 303525.423348011),
                    new Point2D(2400198.6, 303558.48),
                    new Point2D(2400231.65665199, 303260.306799059),
                    new Point2D(2397548.09665199, 302962.796799059),
                    new Point2D(2397515.04, 303260.97),
                }));
        }

        private static DisposalArea GetBeneficialReef3()
        {
            return new DisposalArea(
                "Beneficial Reef 3",
                new Polygon2D(new[]
                {
                    new Point2D(2400385.77997439, 310631.471328049),
                    new Point2D(2400532.34997439, 313026.981328049),
                    new Point2D(2401131.23002561, 312990.338671951),
                    new Point2D(2400984.66002561, 310594.828671951),
                }));
        }

        private static DisposalArea GetBeneficialReef4()
        {
            return new DisposalArea(
                "Beneficial Reef 4",
                new Polygon2D(new[]
                {
                    new Point2D(2401292.07820236, 313489.449067743),
                    new Point2D(2399222.71820236, 314705.059067743),
                    new Point2D(2399526.62179764, 315222.400932257),
                    new Point2D(2401595.98179764, 314006.790932257),
                }));
        }

        private static DisposalArea GetBeneficialReef5()
        {
            return new DisposalArea(
                "Beneficial Reef 5",
                new Polygon2D(new[]
                {
                    new Point2D(2395346.88551822, 317203.891105161),
                    new Point2D(2397519.84551822, 316184.971105161),
                    new Point2D(2397265.11448178, 315641.728894839),
                    new Point2D(2395092.15448178, 316660.648894839),
                }));
        }

        private static DisposalArea GetDumpSite7()
        {
            return new DisposalArea(
                "Dump Site 7",
                new Polygon2D(new[]
                {
                    new Point2D(308127.121, 42533.779),
                    new Point2D(310828.814, 42514.74),
                    new Point2D(312001.114, 40685.538),
                    new Point2D(311516.528, 39171.386),
                    new Point2D(306304.238, 39511.724),
                }));
        }

        private static DisposalArea GetBeneficialReef6()
        {
            return new DisposalArea(
                "Beneficial Reef 6",
                new Polygon2D(new[]
                {
                    new Point2D(2392837.7418616, 312985.794822518),
                    new Point2D(2392194.9018616, 315298.094822518),
                    new Point2D(2392772.9781384, 315458.805177482),
                    new Point2D(2393415.8181384, 313146.505177482),
                }));
        }

        private static DisposalArea GetOdmds(string subName)
        {
            return new DisposalArea(
                $"ODMDS {subName}",
                new Polygon2D(new[]
                {
                    new Point2D(2384312.3, 305185.82),
                    new Point2D(2399371.04, 297104.72),
                    new Point2D(2391795.48, 283067.79),
                    new Point2D(2376741.17, 291170.83)
                }));

        }

        private static Polygon2D GetBerm()
        {
            return new Polygon2D(new[]
            {
                new Point2D(2384451.44, 304741.62),
                new Point2D(2377191.31, 291303.8),
                new Point2D(2391666.37, 283510.82),
                new Point2D(2398930.2, 296972.09),
                new Point2D(2398490.178, 297209.53),
                new Point2D(2391463.56, 284187.86),
                new Point2D(2377869.23, 291506.68),
                new Point2D(2384891.34, 304503.95),
                new Point2D(2384451.439, 304741.618)
            });
        }

        private static DisposalArea GetMitigationReefS()
        {
            return new DisposalArea(
                "Mitigation Reef S",
                new Polygon2D(new[]
                {
                    new Point2D(2394081.001, 314716.6411),
                    new Point2D(2394825.114, 315222.8981),
                    new Point2D(2393832.964, 314547.8888),
                    new Point2D(2394001.716, 314299.8512),
                    new Point2D(2395241.904, 315143.6128),
                    new Point2D(2394735.647, 315887.7256),
                    new Point2D(2393991.534, 315381.4687),
                    new Point2D(2393822.782, 315629.5063),
                    new Point2D(2394814.933, 316304.5156),
                    new Point2D(2394646.18, 316552.5532),
                    new Point2D(2393405.992, 315708.7915),
                    new Point2D(2393912.249, 314964.6787),
                    new Point2D(2394656.362, 315470.9357),
                    new Point2D(2394825.114, 315222.8981)
                }));
        }

        private static DisposalArea GetMitigationReefJ()
        {
            return new DisposalArea(
                "Mitigation Reef J",
                new Polygon2D(new[]
                {
                    new Point2D(2398390.77875363,310165.47652381),
                    new Point2D(2398503.56124638,309887.483476189),
                    new Point2D(2399342.63124637,310228.413476189),
                    new Point2D(2399229.84875363,310506.406523811),
                    new Point2D(2398950.07402739,310392.964247189),
                    new Point2D(2398273.36650995,312060.953493872),
                    new Point2D(2396603.20152469,311375.807050434),
                    new Point2D(2396939.31664036,310540.904951396),
                    new Point2D(2397216.87608829,310654.767276536),
                    new Point2D(2396993.53460338,311209.542310028),
                    new Point2D(2398108.16863387,311670.146813763),
                    new Point2D(2398672.08101868,310280.181770226),
                }));

        }

        private Polygon2D GetChannel()
        {
            return new Polygon2D(new[]
               {
                new Point2D(2354470.93, 331099.96),
                new Point2D(2355311.97, 332180.91),
                new Point2D(2450376.408, 280154.6714),
                new Point2D(2449731.205, 278975.6321),
                new Point2D(2354470.93, 331099.96)
            });
        }

        public bool IsWithinBermArea(Point2D point2D)
        {
            return _berm.DoesBound(point2D);
        }

        public bool ShouldDumpInBermArea(DisposalArea disposalArea)
        {
            return disposalArea == _odmdsEast 
                || disposalArea == _odmdsSouth
                || disposalArea == _odmdsWest;
        }

        public bool IsWithinChannel(Point2D point2D)
        {
            return _channel.DoesBound(point2D);
        }
    }
}
