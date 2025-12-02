using Microsoft.AspNetCore.Http;
using RoomBooker.Application.DTO.Booking;
using RoomBooker.Application.DTO.Room;
using RoomBooker.Application.Interface.Booking;
using RoomBooker.Domain.Entity.Booking;
using RoomBooker.Domain.Entity.Booking.Request;
using RoomBooker.Domain.Exceptions;
using RoomBooker.Domain.Interface.Booking;
using System.Linq.Expressions;


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
            var bookings = await _bookingRepository.SelectBookingRoom(request);
            return bookings.GroupBy(b => new { b.BookingId, b.InitialDate, b.FinalDate, b.Day, b.UserId }).Select(booking => new BookingDTO
            (
                booking.Key.BookingId,
                booking.Key.UserId,
                booking?.Select(r => new RoomDTO(
                    r.RoomId,
                    r.RoomName,
                    r.RoomCapacity,
                    booking?.Select(re => new RoomWithResourceDTO(re.ResourceId, re.ResourceName, re.ResourceRoomQuantity))?.ToList()
                ))?.FirstOrDefault(),
                booking.Key.InitialDate,
                booking.Key.FinalDate,
                booking.Key.Day
            )).ToList();
        }



        private void ValidateBooking(BookingCreateDTO booking)
        {
            if (booking.InitialDate > booking.FinalDate)
                throw new GenericException(new ExceptionResponse(StatusCodes.Status400BadRequest, "Initial date must be before final date"));
            if(booking.UserId <= 0 )
                throw new GenericException(new ExceptionResponse(StatusCodes.Status400BadRequest, "User Id must be greater than zero."));
            if (booking.RoomId <= 0)
                throw new GenericException(new ExceptionResponse(StatusCodes.Status400BadRequest, "Room Id must be greater than zero."));
        }

        private async Task ValidateBookingExists(int bookingId)
        {
            var booking = await _bookingRepository.SelectBooking(new BookingRequest { Id = bookingId });
            if (booking == null)
                throw new GenericException(new ExceptionResponse(StatusCodes.Status404NotFound, "Booking not found"));

        }

        private async Task CheckRoomAvailability(BookingCreateDTO booking)
        {
            var existingBookings = await _bookingRepository.SelectBooking(new BookingRequest { RoomId = booking.RoomId, Day = booking.Day });
            foreach (var existingBooking in existingBookings)
            {
                if (booking.InitialDate >= existingBooking.InitialDate || booking.FinalDate <= existingBooking.FinalDate)
                    throw new GenericException(new ExceptionResponse(StatusCodes.Status400BadRequest, "Room is already booked during this period"));

            }
        }
    }
}
