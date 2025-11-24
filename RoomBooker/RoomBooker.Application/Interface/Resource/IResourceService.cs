using RoomBooker.Application.DTO.Resource;
using RoomBooker.Domain.Entity.Resource.Request;

namespace RoomBooker.Application.Interface.Resource
{
    public interface IResourceService
    {
        Task CreateResourceAsync(ResourceCreateOrUpdateDTO resource);
        Task UpdateResourceAsync(int id, ResourceCreateOrUpdateDTO resource);
        Task DeleteResourceAsync(int id);
        Task<List<ResourceDTO>> SelectResourceAsync(ResourceRequest request);
    }
}
