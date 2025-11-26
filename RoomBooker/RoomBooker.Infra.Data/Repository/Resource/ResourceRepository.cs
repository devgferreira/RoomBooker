using RoomBooker.Domain.Interface.Resource;
using RoomBooker.Infra.Data.Context;
using RoomBooker.Domain.Entity.Resource;
using RoomBooker.Domain.Entity.Resource.Request;
using Dapper;

namespace RoomBooker.Infra.Data.Repository.Resource
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly DbContext _context;

        public ResourceRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateResource(ResourceInfo resource)
        {
            var sql = "INSERT INTO Resource (Name) VALUES (@Name) RETURNING Id;";

            var id = await _context.Connection.ExecuteScalarAsync<int>(sql, new
            {
                Name = resource.Name
            });
            return id;
        }

        public async Task UpdateResource(int id, ResourceInfo resource)
        {
            var sql = "UPDATE Resource SET Name = @Name WHERE Id = @Id";

            await _context.Connection.ExecuteAsync(sql, new
            {
                Id = id,
                Name = resource.Name
            });
        }

        public async Task DeleteResource(int id)
        {
            var sql = "DELETE FROM Resource WHERE Id = @Id";

            await _context.Connection.ExecuteAsync(sql, new
            {
                Id = id
            });
        }

        public async Task<List<ResourceInfo>> SelectResource(ResourceRequest request)
        {
            var sql = "SELECT Id, Name FROM Resource WHERE 1 = 1";

            if (request.Id != null)
            {
                sql += " AND Id = @Id";
            }
            var result = await _context.Connection.QueryAsync<ResourceInfo>(sql, new
            {
                Id = request.Id
            });

            return result.ToList();
        }
    }
}
