using RoomBooker.Application.DTO.Room;


namespace RoomBooker.Application.DTO.Booking
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public RoomDTO RoomDTO { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime Day { get; set; }
    }
}
