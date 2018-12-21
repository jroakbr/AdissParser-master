using System;

namespace Gldd.AdissParser
{
    public class AdissCsvRecord
    {
        public DateTime LocalDateTime { get; set; }

        public double Easting { get; set; }

        public double Northing { get; set; }

        public Point2D XYCoordinate => new Point2D(Easting, Northing);

        public double HeadingDecimalDegrees { get; set; }

        public double SpeedKnots { get; set; }

        public double AftDraftInternationalFeet { get; set; }

        public double ForeDraftInternationalFeet { get; set; }

        public double AverageDraftInternationalFeet => (AftDraftInternationalFeet + ForeDraftInternationalFeet) / 2;

        public double AftUllageInternationalFeet { get; set; }

        public double ForeUllageInternationalFeet { get; set; }

        public double? WaterDepthInternationalFeet { get; set; }

        public PlacementPhase PlacementPhase { get; set; }

        public HullStatus HullStatus { get; set; }
    }
}
