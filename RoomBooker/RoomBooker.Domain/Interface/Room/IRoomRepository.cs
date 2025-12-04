using RoomBooker.Domain.Entity.Room;
using RoomBooker.Domain.Entity.Room.Request;
using RoomBooker.Domain.Entity.Room.Response;

namespace RoomBooker.Domain.Interface.Room
{
    public interface IRoomRepository
    {
        Task<int> CreateRoom(RoomInfo room);
        Task UpdateRoom(int id, RoomInfo room);
        Task DeleteRoom(int id);
        Task<List<RoomInfo>> SelectRoom(RoomRequest request);
        Task<List<RoomWithResourceResponse>> SelectRoomWithResource(RoomRequest request);
    }
}
