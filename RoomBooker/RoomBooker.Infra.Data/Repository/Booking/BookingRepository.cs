using RoomBooker.Domain.Interface.Booking;
using RoomBooker.Domain.Entity.Booking;
using RoomBooker.Domain.Entity.Booking.Request;
using RoomBooker.Domain.Entity.Booking.Response;
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
            var sql = "INSERT INTO Booking (RoomId, InitialDate, FinalDate, UserId, Day) VALUES (@RoomId, @InitialDate, @FinalDate, @UserId, @Day)";
            var id = await _context.Connection.ExecuteScalarAsync<int>(sql,
                new
                {
                    RoomId = booking.RoomId,
                    InitialDate = booking.InitialDate,
                    FinalDate = booking.FinalDate,
                    UserId = booking.UserId,
                    Day = booking.Day
                });
            return id;
        }

        public async Task UpdateBooking(int id, BookingInfo booking)
        {
            var sql = "UPDATE Booking SET RoomId = @RoomId, InitialDate = @InitialDate, FinalDate = @FinalDate, UserId = @UserId, Day = @Day WHERE Id = @Id";
            await _context.Connection.ExecuteAsync(sql,
                new
                {
                    Id = id,
                    RoomId = booking.RoomId,
                    InitialDate = booking.InitialDate,
                    FinalDate = booking.FinalDate,
                    UserId = booking.UserId,
                    Day = booking.Day
                });
        }

        public async Task DeleteBooking(int id)
        {
            var sql = "DELETE FROM Booking WHERE Id = @Id";
            await _context.Connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<List<BookingInfo>> SelectBooking(BookingRequest request)
        {
            var sql = "SELECT * FROM Booking WHERE 1 = 1 "; // ajustar o * com os campos certos
            if (request.RoomId != null)
            {
                sql += "AND RoomId = @RoomId ";
            }
            if (request.UserId != null)
            {
                sql += "AND UserId = @UserId ";
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
            if (request.Day != null)
            {
                sql += "AND Day = @Day ";
            }
            var bookings = await _context.Connection.QueryAsync<BookingInfo>(sql,
                new
                {
                    Id = request.Id,
                    RoomId = request.RoomId,
                    InitialDate = request.InitialDate,
                    FinalDate = request.FinalDate,
                    UserId = request.UserId,
                    Day = request.Day
                });
            return bookings.ToList();
        }

        public async Task<List<BookingRoomResponse>> SelectBookingRoom(BookingRequest request)
        {
            var sql = "SELECT * FROM Booking WHERE 1 = 1 "; // ajustar o * com os campos certos

            if (request.UserId != null)
            {
                sql += "AND UserId = @UserId ";
            }
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
            if (request.Day != null)
            {
                sql += "AND Day = @Day ";
            }
            var bookings = await _context.Connection.QueryAsync<BookingRoomResponse>(sql,
                new
                {
                    Id = request.Id,
                    RoomId = request.RoomId,
                    InitialDate = request.InitialDate,
                    FinalDate = request.FinalDate,
                    UserId = request.UserId,
                    Day = request.Day
                });
            return bookings.ToList();
        }
    }
}
