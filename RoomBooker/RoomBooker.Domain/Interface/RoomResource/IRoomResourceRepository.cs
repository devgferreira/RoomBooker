using RoomBooker.Domain.Entity.RoomResource;
using RoomBooker.Domain.Entity.RoomResource.Request;


namespace RoomBooker.Domain.Interface.RoomResource
{
    public interface IRoomResourceRepository
    {
        Task<int> CreateRoomResource(RoomResourceInfo roomResource);
        Task UpdateRoomResource(int id, RoomResourceInfo roomResource);
        Task DeleteRoomResource(int id);
        Task<List<RoomResourceInfo>> SelectRoomResource(RoomResourceRequest request);
    }
}
