using RoomBooker.Infra.Data.Context;
using RoomBooker.Domain.Entity.RoomResource;
using RoomBooker.Domain.Entity.RoomResource.Request;
using RoomBooker.Domain.Interface.RoomResource;
using Dapper;

namespace RoomBooker.Infra.Data.Repository.RoomResource
{
    public class RoomResourceRepository : IRoomResourceRepository
    {
        private readonly DbContext _context;

        public RoomResourceRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRoomResource(RoomResourceInfo roomResource)
        {
            var sql = "INSERT INTO room_resource (room_id, resource_id, quantity) VALUES (@RoomId, @ResourceId, @Quantity) RETURNING Id;";

            var id = await _context.Connection.ExecuteScalarAsync<int>(sql, new
            {
                RoomId = roomResource.RoomId,
                ResourceId = roomResource.ResourceId,
                Quantity = roomResource.Quantity
            });

            return id;
        }

        public async Task UpdateRoomResource(int id, RoomResourceInfo roomResource)
        {
            var sql = "UPDATE room_resource SET room_id = @RoomId, resource_id = @ResourceId, quantity = @Quantity WHERE Id = @Id;";

            await _context.Connection.ExecuteAsync(sql, new
            {
                Id = id,
                RoomId = roomResource.RoomId,
                ResourceId = roomResource.ResourceId,
                Quantity = roomResource.Quantity
            });
        }

        public async Task DeleteRoomResource(int id)
        {
            var sql = "DELETE FROM room_resource WHERE Id = @Id;";

            await _context.Connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<List<RoomResourceInfo>> SelectRoomResource(RoomResourceRequest request)
        {
            var sql = "SELECT Id, room_id as RoomId, resource_id as ResourceId, quantity FROM room_resource WHERE 1 = 1 ";

            if (request.RoomId.HasValue)
            {
                sql += "AND room_id = @RoomId ";
            }
            if (request.ResourceId.HasValue)
            {
                sql += "AND resource_id = @ResourceId ";
            }
            if (request.Id.HasValue)
            {
                sql += "AND Id = @Id ";
            }

            var roomResources = await _context.Connection.QueryAsync<RoomResourceInfo>(sql, new
            {
                RoomId = request.RoomId,
                ResourceId = request.ResourceId,
                Id = request.Id
            });

            return roomResources.ToList();
        }

    }
}
