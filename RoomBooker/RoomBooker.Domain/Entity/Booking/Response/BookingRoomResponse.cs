namespace RoomBooker.Domain.Entity.Booking.Response
{
    public class BookingRoomResponse
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomCapacity { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime Day { get; set; }
    }
}
