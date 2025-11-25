using RoomBooker.Domain.Entity.Booking;
using RoomBooker.Domain.Entity.Booking.Request;
using RoomBooker.Domain.Entity.Booking.Response;

namespace RoomBooker.Domain.Interface.Booking
{
    public interface IBookingRepository
    {
        Task<int> CreateBooking(BookingInfo booking);
        Task UpdateBooking(int id, BookingInfo booking);
        Task DeleteBooking(int id);
        Task<List<BookingInfo>> SelectBooking(BookingRequest request);
        Task<List<BookingRoomResponse>> SelectBookingRoom(BookingRequest request);
    }
}
