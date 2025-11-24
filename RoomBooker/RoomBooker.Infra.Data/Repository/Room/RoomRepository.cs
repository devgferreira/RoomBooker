using RoomBooker.Domain.Interface.Room;
using RoomBooker.Infra.Data.Context;
using RoomBooker.Domain.Entity.Room;
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
    }
}
