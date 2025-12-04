using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBooker.API.Models.Response;
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
            return Ok(new ApiResponse<BookingDTO>
            {
                Success = true,
                Data = result
            });
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBooking([FromQuery] int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking([FromQuery] int id, [FromBody] BookingUpdateDTO bookingUpdateDTO)
        {
            await _bookingService.UpdateBooking(id, bookingUpdateDTO);
            return Ok();
        }
    }
}
