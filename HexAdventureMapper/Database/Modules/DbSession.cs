using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database.WorkingClasses;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.Database.Modules
{
    public class DbSession : DbModule<Session>
    {
        public override string TableName => "Sessions";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(CurrentMapCornerX, DbColumn.Integer),
            new DbColumn(CurrentMapCornerY, DbColumn.Integer),
            new DbColumn(Year, DbColumn.Integer),
            new DbColumn(Day, DbColumn.Integer),
            new DbColumn(Minutes, DbColumn.Integer)
        };

        public const string CurrentMapCornerX = "CurrentMapCornerX";
        public const string CurrentMapCornerY = "CurrentMapCornerY";
        public const string Year = "Year";
        public const string Day = "Day";
        public const string Minutes = "Minute";

        public DbSession(DbInterface dbInterface, IDbInstance db) : base(dbInterface, db)
        {
        }

        public int CreateDefault()
        {
            var id = 1;
            var x = 0L;
            var y = 0L;
            var year = 382;
            var day = 218;
            var minutes = "1080";

            return Db.Insert(TableName,
                AllColumnNames,
                new object[] { id, x, y, year, day, minutes});
        }

        public Session Get()
        {
            var results = Db.Select(TableName, AllColumnNames);

            if (results.Length > 0)
            {
                var session = MakeObject((object[])results[0]);
                return session;
            }
            return null;
        }

        public void UpdateLocation(HexCoordinate partyLocation)
        {
            Db.Update(TableName, 
                new[] { CurrentMapCornerX, CurrentMapCornerY}, 
                new object[] { partyLocation.X, partyLocation.Y }, 
                new[] { Id }, new object[] { 1 });
        }

        public void UpdateYear(int year)
        {
            Db.Update(TableName,
                new[] { Year },
                new object[] { year },
                new[] { Id }, new object[] { 1 });
        }

        public void UpdateDays(int days)
        {
            Db.Update(TableName,
                new[] { Day },
                new object[] { days },
                new[] { Id }, new object[] { 1 });
        }

        public void UpdateTime(TimeSpan time)
        {
            Db.Update(TableName,
                new[] { Minutes },
                new object[] { time.TotalMinutes },
                new[] { Id }, new object[] { 1 });
        }

        public void UpdateYearAndDays(int year, int days)
        {
            Db.Update(TableName,
                new[] { Year, Day },
                new object[] { year, days },
                new[] { Id }, new object[] { 1 });
        }

        public void UpdateDaysAndTime(int days, TimeSpan time)
        {
            Db.Update(TableName,
                new[] { Day, Minutes },
                new object[] { days, time.TotalMinutes },
                new[] { Id }, new object[] { 1 });
        }

        protected override Session MakeObject(object[] dbObject)
        {
            var currentMapCorner = new HexCoordinate((long)dbObject[1], (long)dbObject[2]);
            var year = GetInt(dbObject[3]);
            var day = GetInt(dbObject[4]);

            var minutes = GetInt(dbObject[5]);
            var hourPart = minutes / 60;
            var minutePart = minutes % 60;
            var timeSpan = new TimeSpan(hourPart, minutePart, 0);

            var session = new Session()
            {
                CurrentMapCorner = currentMapCorner,
                Year = year,
                Day = day,
                Time = timeSpan
            };

            return session;
        }
    }
}
