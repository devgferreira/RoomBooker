using Microsoft.AspNetCore.Mvc;
using RoomBooker.API.Models.Response;
using RoomBooker.Application.DTO.RoomResource;
using RoomBooker.Application.Interface.RoomResource;
using RoomBooker.Domain.Entity.RoomResource.Request;

namespace RoomBooker.API.Controller.RoomResource
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomResourceController : ControllerBase
    {
        private readonly IRoomResourceService _roomResourceService;
        public RoomResourceController(IRoomResourceService roomResourceService)
        {
            _roomResourceService = roomResourceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomResource([FromBody] RoomResourceCreateOrUpdateDTO roomResource)
        {
            await _roomResourceService.CreateRoomResourceAsync(roomResource);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoomResource([FromQuery] int id, [FromBody] RoomResourceCreateOrUpdateDTO roomResource)
        {
            await _roomResourceService.UpdateRoomResourceAsync(id, roomResource);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRoomResource([FromQuery] int id)
        {
            await _roomResourceService.DeleteRoomResourceAsync(id);
            return Ok();
        }
        [HttpGet] 
        public async Task<IActionResult> GetRoomResources([FromQuery] RoomResourceRequest request)
        {
            var roomResources = await _roomResourceService.SelectRoomResourceAsync(request);
            return Ok(new ApiResponse<RoomResourceDTO>
            {
                Success = true,
                Data = roomResources
            });
        }
    }
}
