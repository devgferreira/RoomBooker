namespace RoomBooker.Application.DTO.Booking
{
    public class BookingCreateDTO
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime Day { get; set; }
    }
}
