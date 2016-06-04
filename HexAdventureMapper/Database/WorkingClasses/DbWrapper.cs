using System.Collections.Generic;

namespace HexAdventureMapper.Database.WorkingClasses
{
    public interface IDbHandler
    {
        void LoadDb(string dbPath);
        object[] Select(string table, string[] columns);
        object[] Select(string table, string[] columns, string otherClauses);
        object[] Select(string table, string[] columns, string whereColumn, object whereValue);
        object[] Select(string table, string[] columns, string[] whereColumns, object[] whereValues);
        int Insert(string table, string column, string value);
        int Insert(string table, string[] columns, object[] values);
        void Update(string table, string column, object value, string whereColumn, object whereValue);
        void Update(string table, string column, object value, string[] whereColumns, object[] whereValues);
        void Update(string table, string[] columns, object[] values, string whereColumn, object whereValue);
        void Update(string table, string[] columns, object[] values, string[] whereColumns, object[] whereValues);
        void Delete(string table, string whereColumn, object whereValue);
        void Delete(string table, string[] whereColumns, object[] whereValues);
        void ClearTable(string table);
        void CreateTables(IDbModule[] modules);
    }

    public class DbWrapper : IDbHandler
    {
        private readonly IDbHandler _db;

        public DbWrapper()
        {
            _db = new SqLiteDbHandler();
        }

        public void LoadDb(string dbPath)
        {
            _db.LoadDb(dbPath);
        }

        public object[] Select(string table, string[] columns)
        {
            return _db.Select(table, columns);
        }

        public object[] Select(string table, string[] columns, string otherClauses)
        {
            return _db.Select(table, columns, otherClauses);
        }

        public object[] Select(string table, string[] columns, string whereColumn, object whereValue)
        {
            return _db.Select(table, columns, whereColumn, whereValue);
        }

        public object[] Select(string table, string[] columns, string[] whereColumns, object[] whereValues)
        {
            return _db.Select(table, columns, whereColumns, whereValues);
        }

        public int Insert(string table, string column, string value)
        {
            return _db.Insert(table, column, value);
        }

        public int Insert(string table, string[] columns, object[] values)
        {
            return _db.Insert(table, columns, values);
        }

        public void Update(string table, string column, object value, string whereColumn, object whereValue)
        {
            _db.Update(table, column, value, whereColumn, whereValue);
        }

        public void Update(string table, string column, object value, string[] whereColumns, object[] whereValues)
        {
            _db.Update(table, column, value, whereColumns, whereValues);
        }

        public void Update(string table, string[] columns, object[] values, string whereColumn, object whereValue)
        {
            _db.Update(table, columns, values, whereColumn, whereValue);
        }

        public void Update(string table, string[] columns, object[] values, string[] whereColumns, object[] whereValues)
        {
            _db.Update(table, columns, values, whereColumns, whereValues);
        }

        public void Delete(string table, string whereColumn, object whereValue)
        {
            _db.Delete(table, whereColumn, whereValue);
        }

        public void Delete(string table, string[] whereColumns, object[] whereValues)
        {
            _db.Delete(table, whereColumns, whereValues);
        }

        public void CreateTables(IDbModule[] modules)
        {
            _db.CreateTables(modules);
        }

        public void ClearTable(string table)
        {
            _db.ClearTable(table);
        }
    }
}