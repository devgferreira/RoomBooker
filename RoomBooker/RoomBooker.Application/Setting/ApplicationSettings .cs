namespace RoomBooker.Application.Setting
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string ConnectionString { get; set; } = default!;
    }
}
