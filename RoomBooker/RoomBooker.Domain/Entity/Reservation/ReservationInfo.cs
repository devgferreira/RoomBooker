namespace RoomBooker.Domain.Entity.Reservation
{
    public class ReservationInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime Day { get; set; }
    
    }
}
