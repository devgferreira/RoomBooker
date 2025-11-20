namespace RoomBooker.Domain.Entity.Room.Request
{
    public class RoomRequest
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Capacity { get; set; }
    }
}
