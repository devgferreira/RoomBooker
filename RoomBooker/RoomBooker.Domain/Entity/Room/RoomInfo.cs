namespace RoomBooker.Domain.Entity.Room
{
    public class RoomInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public RoomInfo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public RoomInfo(int id, string name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }
}
