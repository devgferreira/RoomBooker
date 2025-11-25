using RoomBooker.Application.DTO.RoomResource;
using RoomBooker.Domain.Entity.RoomResource.Request;


namespace RoomBooker.Application.Interface.RoomResource
{
    public interface IRoomResourceService
    {
        Task CreateRoomResourceAsync(RoomResourceCreateOrUpdateDTO roomResourceDto);
        Task UpdateRoomResourceAsync(int id, RoomResourceCreateOrUpdateDTO roomResourceDto);
        Task DeleteRoomResourceAsync(int id);
        Task<List<RoomResourceDTO>> SelectRoomResourceAsync(RoomResourceRequest request);
    }
}
