using Microsoft.AspNetCore.Mvc;
using RoomBooker.Application.DTO.Resource;
using RoomBooker.Application.Interface.Resource;
using RoomBooker.Domain.Entity.Resource.Request;
namespace RoomBooker.API.Controller.Resource
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResource([FromBody] ResourceCreateOrUpdateDTO resourceDto)
        {
            await _resourceService.CreateResourceAsync(resourceDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateResource([FromQuery] int id, [FromBody] ResourceCreateOrUpdateDTO resourceDto)
        {
            await _resourceService.UpdateResourceAsync(id, resourceDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteResource([FromQuery] int id)
        {
            await _resourceService.DeleteResourceAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetResource(ResourceRequest request)
        {
            var resources = await _resourceService.SelectResourceAsync(request);
            return Ok(resources);
        }
    }
}
