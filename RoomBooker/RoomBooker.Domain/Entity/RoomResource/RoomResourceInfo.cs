namespace RoomBooker.Domain.Entity.RoomResource
{
    public class RoomResourceInfo
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ResourceId { get; set; }


        public RoomResourceInfo(int roomId, int resourceId)
        {
            RoomId = roomId;
            ResourceId = resourceId;
        }
        public RoomResourceInfo(int id, int roomId, int resourceId)
        {
            Id = id;
            RoomId = roomId;
            ResourceId = resourceId;
        }
    }


}
