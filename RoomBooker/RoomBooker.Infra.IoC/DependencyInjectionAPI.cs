using RoomBooker.Infra.Data.Context;
using RoomBooker.Domain.Interface.Room;
using RoomBooker.Infra.Data.Repository.Room;
using RoomBooker.Domain.Interface.Resource;
using RoomBooker.Infra.Data.Repository.Resource;
using RoomBooker.Domain.Interface.RoomResource;
using RoomBooker.Infra.Data.Repository.RoomResource;
using RoomBooker.Domain.Interface.Booking;
using RoomBooker.Infra.Data.Repository.Booking;
using RoomBooker.Application.Interface.Room;
using RoomBooker.Application.Service.Room;
using RoomBooker.Application.Interface.Resource;
using RoomBooker.Application.Service.Resource;
using RoomBooker.Application.Interface.RoomResource;
using RoomBooker.Application.Service.RoomResource;
using RoomBooker.Application.Interface.Booking;
using RoomBooker.Application.Service.Booking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoomBooker.Application.Setting;

namespace RoomBooker.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddScoped<DbContext>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IRoomResourceRepository, RoomResourceRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IRoomResourceService, RoomResourceService>();
            services.AddScoped<IBookingService, BookingService>();

            var appSettings = new ApplicationSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
            };

            services.AddSingleton<IApplicationSettings>(appSettings);

            return services;
        }
    }
}
