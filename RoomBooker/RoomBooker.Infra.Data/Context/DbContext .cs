using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace RoomBooker.Infra.Data.Context
{
    public class DbContext : IDisposable
    {
        public IDbConnection Connection { get; set; }
        public DbContext(IConfiguration configuration)
        {
            var connStr = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                  ?? configuration.GetConnectionString("DefaultConnection");

            Connection = new NpgsqlConnection(connStr);
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
