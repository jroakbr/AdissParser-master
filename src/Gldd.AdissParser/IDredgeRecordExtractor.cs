using System;
using System.Collections.Generic;

namespace Gldd.AdissParser
{
    public interface IDredgeRecordExtractor
    {
        DredgeRecord ExtractNearestRecord(Dredge dredge, IEnumerable<string> filePaths, DateTime startTransitToDisposalAreaDateTime);
    }
}