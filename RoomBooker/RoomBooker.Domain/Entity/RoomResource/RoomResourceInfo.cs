namespace RoomBooker.Domain.Entity.RoomResource
{
    public class RoomResourceInfo
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ResourceId { get; set; }
        public int Quantity { get; set; }

        public RoomResourceInfo(int roomId, int resourceId, int quantity)
        {
            RoomId = roomId;
            ResourceId = resourceId;
            Quantity = quantity;
        }
        public RoomResourceInfo(int id, int roomId, int resourceId, int quantity)
        {
            Id = id;
            RoomId = roomId;
            ResourceId = resourceId;
            Quantity = quantity;
        }
    }


}
