using System;

namespace Gldd.AdissParser
{
    public class ScowParser
    {
        public Scow ParseFromScowVesselName(string scowVesselName)
        {
            if (scowVesselName.StartsWith("GL")
                && int.TryParse(scowVesselName.Replace("GL", ""), out int glddScowVesselNumber))
            {
                var scowSeries = new ScowSeriesParser().ParseFromGlddScowVesselNumber(glddScowVesselNumber);
                return new GlddScow(scowVesselName, scowSeries);
            }
            else if (scowVesselName == "MX2015")
                return MarinexScow.MX2015;
            else if (scowVesselName == "MX2014")
                return MarinexScow.MX2014;
            else
                throw new ArgumentOutOfRangeException(nameof(scowVesselName), scowVesselName, $"\"{scowVesselName}\" cannot be parsed to a {nameof(Scow)} object.");
        }
    }
}