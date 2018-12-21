namespace Gldd.AdissParser
{
    public class Dredge : Enumeration
    {

        public static readonly Dredge Carolina = NewHydraulic(1, "Carolina");

        public static readonly Dredge Illinois = NewHydraulic(2, "Illinois");

        public static readonly Dredge NewYork = NewMechanical(3, "New York");

        public static readonly Dredge Texas = NewHydraulic(4, "Texas");
        public static readonly Dredge Dredge54 = NewMechanical(4, "Dredge 54");
        public static readonly Dredge Dredge55 = NewMechanical(5, "Dredge 55");
        private static Dredge NewHydraulic(int id, string name)
        {
            return new Dredge(id, name, DredgeType.Hydraulic, true);
        }

        private static Dredge NewMechanical(int id, string name)
        {
            return new Dredge(id, name, DredgeType.Mechanical, false);
        }

        private Dredge(int id, string name, DredgeType dredgeType, bool isUseSpiderBarge) : base(id, name)
        {
            DredgeType = dredgeType;
            IsUseSpiderBarge = isUseSpiderBarge;
        }

        public DredgeType DredgeType { get; }

        public bool IsUseSpiderBarge { get; }
    }
}
