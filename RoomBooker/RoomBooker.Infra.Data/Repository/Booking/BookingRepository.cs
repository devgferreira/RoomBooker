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
            var sql = "INSERT INTO Booking (Room_Id, Initial_Date, Final_Date, User_Id, Day) VALUES (@RoomId, @InitialDate, @FinalDate, @UserId, @Day)";
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
            var sql = "UPDATE Booking SET Room_Id = @RoomId, Initial_Date = @InitialDate, Final_Date = @FinalDate, User_Id = @UserId, Day = @Day WHERE Id = @Id";
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
            var sql = "SELECT id, user_id as UserId, room_id as RoomId, initial_date as InitialDate, final_date as FinalDate, Day FROM Booking WHERE 1 = 1 "; // ajustar o * com os campos certos
            if (request.RoomId != null)
            {
                sql += "AND Room_Id = @RoomId ";
            }
            if (request.UserId != null)
            {
                sql += "AND UserId = @UserId ";
            }
            if (request.InitialDate != null && request.FinalDate != null)
            {
                sql += "AND Initial_Date >= @InitialDate ";
            }
            if (request.FinalDate != null)
            {
                sql += "AND Final_Date <= @FinalDate ";
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
            var sql = @"
                            SELECT 	b.ID as BookingId,	
		                            1 as UserId, 
		                            r.Id as RoomId,
		                            r.Name as RoomName,
		                            r.Capacity as RoomCapacity,
		                            re.Id as ResourceId,
		                            re.Name as ResourceName,
		                            rr.Quantity as ResourceRoomQuantity,
		                            b.initial_date as InitialDate,
		                            b.final_date as FinalDate,
		                            b.Day as Day
                            FROM booking b
                            INNER JOIN room r ON b.room_id = r.id
                            INNER JOIN room_resource rr ON r.id = rr.room_id
                            INNER JOIN resource re ON rr.resource_id = re.id
                            WHERE 1 = 1
                            "; // ajustar o id do usuario


            if (request.UserId != null)
            {
                sql += " AND User_Id = @UserId ";
            }
            if (request.RoomId != null)
            {
                sql += " AND b.Room_Id = @RoomId ";
            }
            if (request.InitialDate != null)
            {
                sql += " AND b.Initial_Date >= @InitialDate ";
            }
            if (request.FinalDate != null)
            {
                sql += " AND b.Final_Date <= @FinalDate ";
            }
            if (request.Id != null)
            {
                sql += " AND b.Id = @Id ";
            }
            if (request.Day != null)
            {
                sql += " AND b.Day = @Day ";
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
