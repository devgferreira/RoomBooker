using RoomBooker.Application.DTO.Room;


namespace RoomBooker.Application.DTO.Booking
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public RoomDTO RoomDTO { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime Day { get; set; }

        public BookingDTO(int id, int userId, RoomDTO roomDTO, DateTime initialDate, DateTime finalDate, DateTime day)
        {
            Id = id;
            UserId = userId;
            RoomDTO = roomDTO;
            InitialDate = initialDate;
            FinalDate = finalDate;
            Day = day;
        }
    }
}
