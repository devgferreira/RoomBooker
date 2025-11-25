using RoomBooker.Application.Interface.RoomResource;
using RoomBooker.Domain.Entity.RoomResource;
using RoomBooker.Domain.Entity.RoomResource.Request;
using RoomBooker.Application.DTO.RoomResource;
using RoomBooker.Domain.Interface.RoomResource;

namespace RoomBooker.Application.Service.RoomResource
{
    public class RoomResourceService : IRoomResourceService
    {
        private readonly IRoomResourceRepository _roomResourceRepository;

        public RoomResourceService(IRoomResourceRepository roomResourceRepository)
        {
            _roomResourceRepository = roomResourceRepository;
        }

        public async Task CreateRoomResourceAsync(RoomResourceCreateOrUpdateDTO roomResourceCreateOrUpdateDTO)
        {
            ValidateRoomResource(roomResourceCreateOrUpdateDTO);
            var roomResource = new RoomResourceInfo(roomResourceCreateOrUpdateDTO.RoomId, roomResourceCreateOrUpdateDTO.ResourceId,
                roomResourceCreateOrUpdateDTO.Quantity);
            await _roomResourceRepository.CreateRoomResource(roomResource);
        }

        public async Task UpdateRoomResourceAsync(int id, RoomResourceCreateOrUpdateDTO roomResourceCreateOrUpdateDTO)
        {
            ValidateRoomResource(roomResourceCreateOrUpdateDTO);
            await ValidateRoomResourceExists(id);
            var roomResource = new RoomResourceInfo(roomResourceCreateOrUpdateDTO.RoomId, roomResourceCreateOrUpdateDTO.ResourceId,
                roomResourceCreateOrUpdateDTO.Quantity);
            await _roomResourceRepository.UpdateRoomResource(id, roomResource);
        }

        public async Task DeleteRoomResourceAsync(int id)
        {
            await ValidateRoomResourceExists(id);
            await _roomResourceRepository.DeleteRoomResource(id);
        }

        public async Task<List<RoomResourceDTO>> SelectRoomResourceAsync(RoomResourceRequest request)
        {
            var roomResources = await _roomResourceRepository.SelectRoomResource(request);
            return roomResources.Select(r => new RoomResourceDTO(r.Id, r.RoomId, r.ResourceId, r.Quantity)).ToList();
        }

        private void ValidateRoomResource(RoomResourceCreateOrUpdateDTO roomResource)
        {
            if (roomResource == null)
                throw new ArgumentNullException(nameof(roomResource));

            if (roomResource.RoomId <= 0)
                throw new ArgumentException("Room ID must be greater than zero.", nameof(roomResource.RoomId));

            if (roomResource.ResourceId <= 0)
                throw new ArgumentException("Resource ID must be greater than zero.", nameof(roomResource.ResourceId));

            if (roomResource.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(roomResource.Quantity));
        }

        private async Task ValidateRoomResourceExists(int id)
        {
            var roomResource = await _roomResourceRepository.SelectRoomResource(new RoomResourceRequest { Id = id });
            if (roomResource == null)
                throw new ArgumentException("Room resource does not exist.", nameof(id));
        }
    }
}
