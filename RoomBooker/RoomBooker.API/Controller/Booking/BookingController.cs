using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBooker.Application.DTO.Booking;
using RoomBooker.Application.DTO.Resource;
using RoomBooker.Application.Interface.Booking;
using RoomBooker.Domain.Entity.Booking.Request;

namespace RoomBooker.API.Controller.Booking
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService) {
            _bookingService = bookingService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDTO bookingDTO)
        {
            await _bookingService.CreateBookingAsync(bookingDTO);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> SelectBookingRoom([FromQuery] BookingRequest request)
        {
            var result = await _bookingService.SelectBookingAsync(request);
            return Ok(result);
        }
    }
}
