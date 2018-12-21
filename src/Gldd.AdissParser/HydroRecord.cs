using System;

namespace Gldd.AdissParser
{
    public class HydroRecord
    {
        public HydroRecord(DateTime dateTime, double cutterX, double cutterY, float cutterStation, float ladderDepth)
        {
            DateTime = dateTime;
            CutterX = cutterX;
            CutterY = cutterY;
            CutterStation = cutterStation;
            LadderDepth = ladderDepth;
        }

        public DateTime DateTime { get; }

        public double CutterX { get; }

        public double CutterY { get; }

        public float CutterStation { get; }

        public float LadderDepth { get; }
    }
}
