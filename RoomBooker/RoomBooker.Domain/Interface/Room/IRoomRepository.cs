using RoomBooker.Domain.Entity.Room;
using RoomBooker.Domain.Entity.Room.Request;

namespace RoomBooker.Domain.Interface.Room
{
    public interface IRoomRepository
    {
        Task<int> CreateRoom(RoomInfo room);
        Task UpdateRoom(int id, RoomInfo room);
        Task DeleteRoom(int id);
        Task<List<RoomInfo>> SelectRoom(RoomRequest request);
    }
}
