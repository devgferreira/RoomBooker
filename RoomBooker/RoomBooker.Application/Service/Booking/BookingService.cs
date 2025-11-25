using RoomBooker.Application.Interface.Booking;
using RoomBooker.Domain.Entity.Booking;
using RoomBooker.Domain.Entity.Booking.Request;
using RoomBooker.Application.DTO.Booking;
using RoomBooker.Domain.Interface.Booking;


namespace RoomBooker.Application.Service.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }


        public async Task CreateBookingAsync(BookingCreateDTO request)
        {
            ValidateBooking(request);
            await CheckRoomAvailability(request);
            var booking = new BookingInfo(request.RoomId, request.UserId, request.InitialDate, request.FinalDate, request.Day);
            await _bookingRepository.CreateBooking(booking);
        }
        public async Task DeleteBookingAsync(int bookingId)
        {
            await ValidateBookingExists(bookingId);
            await _bookingRepository.DeleteBooking(bookingId);
        }
        public async Task<List<BookingDTO>> SelectBookingAsync(BookingRequest request)
        {
            var bookings = await _bookingRepository.SelectBooking(request);
            return new List<BookingDTO>();
        }

        private void ValidateBooking(BookingCreateDTO booking)
        {
            if (booking.InitialDate > booking.FinalDate)
                throw new ArgumentException("Initial date must be before final date");
        }

        private async Task ValidateBookingExists(int bookingId)
        {
            var booking = await _bookingRepository.SelectBooking(new BookingRequest { Id = bookingId });
            if (booking == null)
                throw new ArgumentException("Booking not found");
        }

        private async Task CheckRoomAvailability(BookingCreateDTO booking)
        {
            var existingBookings = await _bookingRepository.SelectBooking(new BookingRequest { RoomId = booking.RoomId });
            foreach (var existingBooking in existingBookings)
            {
                if (booking.InitialDate >= existingBooking.InitialDate && booking.InitialDate <= existingBooking.FinalDate)
                    throw new ArgumentException("Room is already booked during this period");
            }
        }
    }
}
