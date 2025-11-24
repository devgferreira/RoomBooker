using RoomBooker.Domain.Interface.Room;
using RoomBooker.Infra.Data.Context;
using RoomBooker.Domain.Entity.Room;
using RoomBooker.Domain.Entity.Room.Request;
using Dapper;
namespace RoomBooker.Infra.Data.Interface.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DbContext _context;

        public RoomRepository(DbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateRoom(RoomInfo room)
        {
            var sql = "INSERT INTO Room (Name, Capacity) VALUES (@Name, @Capacity) RETURNING Id;";
            var id = await _context.Connection.ExecuteScalarAsync<int>(sql, new { Name = room.Name, Capacity = room.Capacity });
            return id;
        }

        public async Task UpdateRoom(RoomInfo room)
        {
            var sql = "UPDATE Room SET Name = @Name, Capacity = @Capacity WHERE Id = @Id;";
            await _context.Connection.ExecuteAsync(sql, new { Id = room.Id, Name = room.Name, Capacity = room.Capacity });
        }

        public async Task<List<RoomInfo>> SelectRoom(RoomRequest request)
        {
            var sql = "SELECT Id, Name, Capacity FROM Room WHERE Name LIKE @Name AND Capacity = @Capacity;";
            var rooms = await _context.Connection.QueryAsync<RoomInfo>(sql, new { Name = $"%{request.Name}%", Capacity = request.Capacity });
            return rooms.ToList();
        }
    }
}
