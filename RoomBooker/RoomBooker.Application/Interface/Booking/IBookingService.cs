using RoomBooker.Application.DTO.Booking;
using RoomBooker.Domain.Entity.Booking.Request;

namespace RoomBooker.Application.Interface.Booking
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingCreateDTO bookingCreateDTO);
        Task DeleteBookingAsync(int id);
        Task<List<BookingDTO>> SelectBookingAsync(BookingRequest request);
        Task UpdateBooking(int id, BookingUpdateDTO bookingUpdateDTO);
    }
}
