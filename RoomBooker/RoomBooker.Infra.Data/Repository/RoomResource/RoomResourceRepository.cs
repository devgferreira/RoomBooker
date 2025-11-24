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
            var sql = "INSERT INTO RoomResources (RoomId, ResourceId) VALUES (@RoomId, @ResourceId) RETURNING Id;";

            var id = await _context.Connection.ExecuteScalarAsync<int>(sql, new
            {
                RoomId = roomResource.RoomId,
                ResourceId = roomResource.ResourceId
            });

            return id;
        }

        public async Task UpdateRoomResource(int id, RoomResourceInfo roomResource)
        {
            var sql = "UPDATE RoomResources SET RoomId = @RoomId, ResourceId = @ResourceId WHERE Id = @Id;";

            await _context.Connection.ExecuteAsync(sql, new
            {
                Id = id,
                RoomId = roomResource.RoomId,
                ResourceId = roomResource.ResourceId
            });
        }

        public async Task DeleteRoomResource(int id)
        {
            var sql = "DELETE FROM RoomResources WHERE Id = @Id;";

            await _context.Connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<List<RoomResourceInfo>> SelectRoomResource(RoomResourceRequest request)
        {
            var sql = "SELECT Id, RoomId, ResourceId FROM RoomResources WHERE 1 = 1 ";

            if (request.RoomId.HasValue)
            {
                sql += "AND RoomId = @RoomId ";
            }
            if (request.ResourceId.HasValue)
            {
                sql += "AND ResourceId = @ResourceId ";
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
