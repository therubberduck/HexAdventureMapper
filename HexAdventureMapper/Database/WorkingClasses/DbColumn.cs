using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.Database.WorkingClasses
{
    public class DbColumn
    {
        public const string Integer = "INTEGER";
        public const string Real = "REAL";
        public const string Text = "TEXT";

        public string Name { get; }
        public string Type { get; }
        public bool IsPrimaryKey { get; }

        public DbColumn(string name, string type, bool isPrimaryKey = false)
        {
            Name = name;
            Type = type;
            IsPrimaryKey = isPrimaryKey;
        }
    }
}
