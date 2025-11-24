using RoomBooker.Application.Interface.Resource;
using RoomBooker.Domain.Entity.Resource;
using RoomBooker.Domain.Entity.Resource.Request;
using RoomBooker.Application.DTO.Resource;
using RoomBooker.Domain.Interface.Resource;


namespace RoomBooker.Application.Service.Resource
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task CreateResourceAsync(ResourceCreateOrUpdateDTO request)
        {
            ValidateResource(request);
            var resource = new ResourceInfo(request.Name);
            await _resourceRepository.CreateResource(resource);
        }
        public async Task UpdateResourceAsync(int id, ResourceCreateOrUpdateDTO request)
        {
            await ValidateResourceExists(id);
            await _resourceRepository.UpdateResource(id, new ResourceInfo(request.Name));
        }
        public async Task DeleteResourceAsync(int id)
        {
            await ValidateResourceExists(id);
            await _resourceRepository.DeleteResource(id);
        }
        public async Task<List<ResourceDTO>> SelectResourceAsync(ResourceRequest request)
        {
            var resources = await _resourceRepository.SelectResource(request);
            return resources.Select(r => new ResourceDTO(r.Id, r.Name)).ToList();
        }

        private void ValidateResource(ResourceCreateOrUpdateDTO request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("Resource name cannot be empty");
            }
        }
        private async Task ValidateResourceExists(int id)
        {
            var resource = await _resourceRepository.SelectResource(new ResourceRequest { Id = id });
            if (resource == null)
            {
                throw new ArgumentException("Resource does not exist");
            }
        }
    }
}
