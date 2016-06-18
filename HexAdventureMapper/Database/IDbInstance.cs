using HexAdventureMapper.Database.WorkingClasses;

namespace HexAdventureMapper.Database
{
    public interface IDbInstance
    {
        void LoadDb(string dbPath);
        void ReloadDb();
        long GetVersion();
        void SetVersion(long version);

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

        void AlterAddColumn(string table, string columnName, string columnType, bool notNull, string defaultValue);
        void ClearTable(string table);
        void CreateTables(IDbModule[] modules);
    }
}