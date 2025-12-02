using System.Text.Json.Serialization;

namespace RoomBooker.API.Models.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}
