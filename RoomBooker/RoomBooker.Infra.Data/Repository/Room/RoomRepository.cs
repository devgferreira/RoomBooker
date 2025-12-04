using Dapper;
using RoomBooker.Domain.Entity.Room;
using RoomBooker.Domain.Entity.Room.Request;
using RoomBooker.Domain.Entity.Room.Response;
using RoomBooker.Domain.Interface.Room;
using RoomBooker.Infra.Data.Context;
namespace RoomBooker.Infra.Data.Repository.Room
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

        public async Task UpdateRoom(int id, RoomInfo room)
        {
            var sql = "UPDATE Room SET Name = @Name, Capacity = @Capacity WHERE Id = @Id;";
            await _context.Connection.ExecuteAsync(sql, new { Id = id, Name = room.Name, Capacity = room.Capacity });
        }

        public async Task<List<RoomInfo>> SelectRoom(RoomRequest request)
        {
            var sql = "SELECT Id, Name, Capacity FROM Room WHERE 1 = 1";
            if (request.Id != null)
            {
                sql += " AND Id = @Id";
            }
            if (request.Name != null)
            {
                sql += " AND Name LIKE @Name";
            }
            if (request.Capacity != null)
            {
                sql += " AND Capacity = @Capacity";
            }
            var rooms = await _context.Connection.QueryAsync<RoomInfo>(sql, new
            {
                Name = $"%{request.Name}%",
                Capacity = request.Capacity,
                Id = request.Id
            });
            return rooms.ToList();
        }
        public async Task<List<RoomWithResourceResponse>> SelectRoomWithResource(RoomRequest request)
        {
            var sql = "SELECT 	r.ID as RoomId, " +
		                  "  r.Name as RoomName, " +
		                  "  r.Capacity as RoomCapacity, " +
		                  "  re.Id as ResourceId, " +
                          "  re.Name as ResourceName, " +
                          "  rr.Quantity as ResourceQuantity " +
                    "FROM Room r " +
                    "INNER JOIN room_resource rr ON r.id = rr.room_id " +
                    "INNER JOIN resource re ON rr.resource_id = re.id " +
                    "WHERE 1 = 1 "
                    		;
            if (request.Id != null)
            {
                sql += "  AND r.Id = @Id";
            }
            if (request.Name != null)
            {
                sql += "  AND r.Name LIKE @Name";
            }
            if (request.Capacity != null)
            {
                sql += " AND r.Capacity = @Capacity";
            }
            var rooms = await _context.Connection.QueryAsync<RoomWithResourceResponse>(sql, new
            {
                Name = $"%{request.Name}%",
                Capacity = request.Capacity,
                Id = request.Id
            });
            return rooms.ToList();
        }
        public async Task DeleteRoom(int id)
        {
            var sql = "DELETE FROM Room WHERE Id = @Id;";
            await _context.Connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
