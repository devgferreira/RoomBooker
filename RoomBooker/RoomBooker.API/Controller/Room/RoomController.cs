using Microsoft.AspNetCore.Mvc;
using RoomBooker.API.Models.Response;
using RoomBooker.Application.DTO.Room;
using RoomBooker.Application.Interface.Room;
using RoomBooker.Domain.Entity.Room.Request;

namespace RoomBooker.API.Controller.Room
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomCreateOrUpdateDTO room)
        {
            await _roomService.CreateRoomAsync(room);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromQuery] int id, [FromBody] RoomCreateOrUpdateDTO room)
        {
            await _roomService.UpdateRoomAsync(id, room);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoom([FromQuery] int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetRooms([FromQuery] RoomRequest request)
        {
            var rooms = await _roomService.SelectRoomAsync(request);
            return Ok(new ApiResponse<RoomDTO>
            {
                Success = true,
                Data = rooms
            });
        }
    }
}
