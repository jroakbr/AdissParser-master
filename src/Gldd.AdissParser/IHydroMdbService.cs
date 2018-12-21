using System;
using System.Collections.Generic;

namespace Gldd.AdissParser
{
    public interface IHydroMdbService
    {
        HydroRecord QueryNearestRecordByDateTime(IEnumerable<string> filePaths, DateTime dateTime, TimeSpan margin);
    }
}