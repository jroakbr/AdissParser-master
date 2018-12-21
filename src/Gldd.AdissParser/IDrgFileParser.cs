using System;
using System.Collections.Generic;

namespace Gldd.AdissParser
{
    public interface IDrgFileParser
    {
        DrgRecord ParseNearestRecordByDateTime(IEnumerable<string> filePaths, DateTime dateTime, TimeSpan margin);
    }
}