using RoomBooker.Application.Interface.Room;
using RoomBooker.Domain.Entity.Room;
using RoomBooker.Domain.Entity.Room.Request;
using RoomBooker.Application.DTO.Room;
using RoomBooker.Domain.Interface.Room;

namespace RoomBooker.Application.Service.Room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task CreateRoomAsync(RoomCreateOrUpdateDTO request)
        {
            ValidateRoom(request);
            var room = new RoomInfo(request.Name, request.Capacity);
            await _roomRepository.CreateRoom(room);
        }

        public async Task UpdateRoomAsync(int id, RoomCreateOrUpdateDTO request)
        {
            await ValidateRoomExists(id);
            var room = new RoomInfo(request.Name, request.Capacity);
            await _roomRepository.UpdateRoom(id, room);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await ValidateRoomExists(id);
            await _roomRepository.DeleteRoom(id);
        }

        public async Task<List<RoomDTO>> SelectRoomAsync(RoomRequest request)
        {
            var rooms = await _roomRepository.SelectRoom(request);
            return rooms.Select(room => new RoomDTO(room.Id, room.Name, room.Capacity)).ToList();
        }

        private void ValidateRoom(RoomCreateOrUpdateDTO room)
        {
            if (string.IsNullOrEmpty(room.Name))
                throw new ArgumentException("Room name cannot be empty.");

            if (room.Capacity <= 0)
                throw new ArgumentException("Room capacity must be greater than zero.");
        }

        private async Task ValidateRoomExists(int id)
        {
            var room = await _roomRepository.SelectRoom(new RoomRequest { Id = id });
            if (room == null)
                throw new ArgumentException("Room does not exist.");
        }
    }
}
