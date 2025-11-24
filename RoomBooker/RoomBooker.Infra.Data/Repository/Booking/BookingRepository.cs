using RoomBooker.Domain.Interface.Booking;
using RoomBooker.Domain.Entity.Booking;
using RoomBooker.Domain.Entity.Booking.Request;
using RoomBooker.Infra.Data.Context;
using Dapper;


namespace RoomBooker.Infra.Data.Repository.Booking
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbContext _context;

        public BookingRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateBooking(BookingInfo booking)
        {
            var sql = "INSERT INTO Bookings (RoomId, InitialDate, FinalDate, UserId) VALUES (@RoomId, @InitialDate, @FinalDate, @UserId)";
            var id = await _context.Connection.ExecuteScalarAsync<int>(sql,
                new
                {
                    RoomId = booking.RoomId,
                    InitialDate = booking.InitialDate,
                    FinalDate = booking.FinalDate,
                    UserId = booking.UserId
                });
            return id;
        }

        public async Task UpdateBooking(int id, BookingInfo booking)
        {
            var sql = "UPDATE Bookings SET RoomId = @RoomId, InitialDate = @InitialDate, FinalDate = @FinalDate, UserId = @UserId WHERE Id = @Id";
            await _context.Connection.ExecuteAsync(sql,
                new
                {
                    Id = id,
                    RoomId = booking.RoomId,
                    InitialDate = booking.InitialDate,
                    FinalDate = booking.FinalDate,
                    UserId = booking.UserId
                });
        }

        public async Task DeleteBooking(int id)
        {
            var sql = "DELETE FROM Bookings WHERE Id = @Id";
            await _context.Connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<List<BookingInfo>> SelectBooking(BookingRequest request)
        {
            var sql = "SELECT * FROM Bookings WHERE 1 = 1 ";
            if (request.RoomId != null)
            {
                sql += "AND RoomId = @RoomId ";
            }
            if (request.InitialDate != null && request.FinalDate != null)
            {
                sql += "AND InitialDate >= @InitialDate ";
            }
            if (request.FinalDate != null)
            {
                sql += "AND FinalDate <= @FinalDate ";
            }
            if (request.Id != null)
            {
                sql += "AND Id = @Id ";
            }
            var bookings = await _context.Connection.QueryAsync<BookingInfo>(sql,
                new
                {
                    Id = request.Id,
                    RoomId = request.RoomId,
                    InitialDate = request.InitialDate,
                    FinalDate = request.FinalDate
                });
            return bookings.ToList();
        }
    }
}
