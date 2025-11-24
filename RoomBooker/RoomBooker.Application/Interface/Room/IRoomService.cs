using RoomBooker.Application.DTO.Room;
using RoomBooker.Domain.Entity.Room.Request;
namespace RoomBooker.Application.Interface.Room
{
    public interface IRoomService
    {
        Task CreateAsync(RoomCreateOrUpdateDTO room);
        Task UpdateAsync(int id, RoomCreateOrUpdateDTO room);
        Task DeleteAsync(int id);
        Task<List<RoomDTO>> SelecetRoom(RoomRequest request);
    }
}
