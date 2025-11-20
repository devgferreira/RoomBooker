namespace RoomBooker.Domain.Entity.Booking
{
    public class BookingInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime Day { get; set; }

    }
}
