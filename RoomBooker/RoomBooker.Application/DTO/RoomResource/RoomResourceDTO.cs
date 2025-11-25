namespace RoomBooker.Application.DTO.RoomResource
{
    public class RoomResourceDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ResourceId { get; set; }
        public int Quantity { get; set; }
        public RoomResourceDTO(int id, int roomId, int resourceId, int quantity)
        {
            Id = id;
            RoomId = roomId;
            ResourceId = resourceId;
            Quantity = quantity;
        }

    }
}
