using RoomBooker.Application.DTO.Room;
using RoomBooker.Domain.Entity.Room.Request;
namespace RoomBooker.Application.Interface.Room
{
    public interface IRoomService
    {
        Task CreateRoomAsync(RoomCreateOrUpdateDTO room);
        Task UpdateRoomAsync(int id, RoomCreateOrUpdateDTO room);
        Task DeleteRoomAsync(int id);
        Task<List<RoomDTO>> SelectRoomAsync(RoomRequest request);
    }
}
