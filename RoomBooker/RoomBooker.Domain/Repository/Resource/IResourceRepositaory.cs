using RoomBooker.Domain.Entity.Resource;
using RoomBooker.Domain.Entity.Resource.Request;

namespace RoomBooker.Domain.Repository.Resource
{
    public interface IResourceRepositaory
    {
        Task<int> CreateResource(ResourceInfo resource);
        Task UpdateResource(int id, ResourceInfo resource);
        Task DeleteResource(int id);
        Task<List<ResourceInfo>> SelectResource(ResourceRequest request);
    }
}
