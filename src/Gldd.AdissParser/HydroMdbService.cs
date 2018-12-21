using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;

namespace Gldd.AdissParser
{
    public class HydroMdbService : IHydroMdbService
    {
        public HydroRecord QueryNearestRecordByDateTime(IEnumerable<string> filePaths, DateTime dateTime, TimeSpan margin)
        {
            return filePaths
                .Select(f => QueryNearestRecordByDateTime(f, dateTime, margin))
                .FirstOrDefault(r => r != null);
        }

        private HydroRecord QueryNearestRecordByDateTime(string filepath, DateTime dateTime, TimeSpan margin)
        {
            string driver = "{Microsoft Access Driver (*.mdb, *.accdb)}";
            string connectionString = $@"Driver={driver};Dbq={filepath}";

            using (var connection = new OdbcConnection(connectionString))
            {
                connection.Open();

                return connection.Query(@"SELECT Date, Time, Cutter_X, Cutter_Y, Cutter_S, Ladder_Depth FROM HYDRO")
                    .Select(row => new HydroRecord(
                        dateTime: DateTime.Parse(row.Date + " " + row.Time),
                        cutterX: (double)row.Cutter_X,
                        cutterY: (double)row.Cutter_Y,
                        cutterStation: (float)row.Cutter_S,
                        ladderDepth: (float)row.Ladder_Depth))
                    .FirstOrDefault(r => r.DateTime >= dateTime && r.DateTime <= dateTime.Add(margin));
            }
        }
    }
}
