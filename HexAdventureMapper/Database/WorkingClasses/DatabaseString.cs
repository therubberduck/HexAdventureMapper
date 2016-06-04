namespace HexAdventureMapper.Database.WorkingClasses
{
    public class DatabaseString
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public DatabaseString(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
