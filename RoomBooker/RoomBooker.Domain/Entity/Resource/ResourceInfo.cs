namespace RoomBooker.Domain.Entity.Resource
{
    public class ResourceInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ResourceInfo(string name)
        {
            Name = name;
        }
        public ResourceInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
