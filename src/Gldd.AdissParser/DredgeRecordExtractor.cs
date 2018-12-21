using System;
using System.Collections.Generic;

namespace Gldd.AdissParser
{
    public class DredgeRecordExtractor : IDredgeRecordExtractor
    {
        private readonly IHydroMdbService hydroMdbService;
        private readonly IDrgFileParser drgFileParser;

        public DredgeRecordExtractor(IHydroMdbService hydroMdbService, IDrgFileParser drgFileParser)
        {
            this.hydroMdbService = hydroMdbService;
            this.drgFileParser = drgFileParser;
        }

        public DredgeRecord ExtractNearestRecord(Dredge dredge, IEnumerable<string> filePaths, DateTime startTransitToDisposalAreaDateTime)
        {
            TimeSpan margin = TimeSpan.FromSeconds(10);
            if (dredge.DredgeType == DredgeType.Hydraulic)
            {
                return hydroMdbService.QueryNearestRecordByDateTime(filePaths, startTransitToDisposalAreaDateTime, margin)?.ToDredgeRecord();
            }
            else if(dredge.DredgeType == DredgeType.Mechanical)
            {
                return drgFileParser.ParseNearestRecordByDateTime(filePaths, startTransitToDisposalAreaDateTime, margin)?.ToDredgeRecord();
            }
            else
            {
                throw new NotSupportedException($"Dredge type {dredge.DredgeType} not yet supported for data extraction.");
            }
        }
    }

    public static class Extensions
    {
        public static DredgeRecord ToDredgeRecord(this DrgRecord drgRecord)
        {
            return new DredgeRecord(
                x: drgRecord.BucketX,
                y: drgRecord.BucketY,
                depth: drgRecord.BucketDepth,
                station: drgRecord.BucketStation);
        }

        public static DredgeRecord ToDredgeRecord(this HydroRecord hydroRecord)
        {
            return new DredgeRecord(
                x: hydroRecord.CutterX,
                y: hydroRecord.CutterY,
                depth: hydroRecord.LadderDepth,
                station: hydroRecord.CutterStation);
        }
    }
}
