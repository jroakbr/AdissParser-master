using System;

namespace Gldd.AdissParser
{
    public class ScowSeriesParser
    {
        public ScowSeries ParseFromGlddScowVesselNumber(int glddScowVesselNumber)
        {
            if (glddScowVesselNumber >= 60 && glddScowVesselNumber <= 69)
                return ScowSeries._60;
            else if (glddScowVesselNumber >= 500 && glddScowVesselNumber <= 599)
                return ScowSeries._500;
            else if (glddScowVesselNumber >= 600 && glddScowVesselNumber <= 699)
                return ScowSeries._600;
            else if (glddScowVesselNumber >= 700 && glddScowVesselNumber <= 799)
                return ScowSeries._700;
            else
                throw new ArgumentOutOfRangeException(nameof(glddScowVesselNumber), glddScowVesselNumber, $"Value of {glddScowVesselNumber} has no corresponding {nameof(ScowSeries)} item.");
        }
    }
}
