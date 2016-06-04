using System.Collections.Generic;
using System.Linq;

namespace HexAdventureMapper.Database.WorkingClasses
{
    public abstract class DbModule<T> : IDbModule
    {
        protected DbInterface DbInterface;
        protected DbWrapper Db;
        
        public abstract string TableName { get; }
        public abstract DbColumn[] AllColumns { get; }
        public string[] AllColumnNames { get; }
        public const string Id = "Id";

        protected DbModule(DbInterface dbInterface, DbWrapper db)
        {
            DbInterface = dbInterface;
            Db = db;
            AllColumnNames = new string[AllColumns.Length];
            for (int i = 0; i < AllColumns.Length; i++)
            {
                AllColumnNames[i] = AllColumns[i].Name;
            }
        }

        public List<T> GetAll()
        {
            var returnList = new List<T>();

            var result = Db.Select(TableName, AllColumnNames);
            foreach (object[] o in result)
            {
                var resultObject = MakeObject(o);
                returnList.Add(resultObject);
            }
            return returnList;
        }

        public T Get(int id)
        {
            object[] result = Db.Select(TableName, AllColumnNames, Id, id);
            if (!result.Any())
            {
                return default(T);
            }

            var o = (object[])result[0];
            var returnObject = MakeObject(o);
            return returnObject;
        }

        public List<int> GetAllIds()
        {
            var ids = new List<int>();

            var result = Db.Select(TableName, new[] { Id });
            foreach (object[] o in result)
            {
                var dbId = (int)(long)o[0];
                ids.Add(dbId);
            }
            return ids;
        }

        public void Remove(int id)
        {
            Db.Delete(TableName, Id, id);
        }

        public void ClearTable()
        {
            Db.ClearTable(TableName);
        }

        protected abstract T MakeObject(object[] dbObject);

        protected int GetInt(object dbObject)
        {
            return (int) (long) dbObject;
        }
    }
}