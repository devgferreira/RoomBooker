using RoomBooker.Domain.Entity.Booking;
using RoomBooker.Domain.Entity.Booking.Request;

namespace RoomBooker.Domain.Repository.Booking
{
    public interface IBookingRepository
    {
        Task<int> CreateBooking(BookingInfo booking);
        Task UpdateBooking(int id, BookingInfo booking);
        Task DeleteBooking(int id);
        Task<List<BookingInfo>> SelectBooking(BookingRequest request);
    }
}
