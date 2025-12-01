
namespace RoomBooker.Application.DTO.Room;

public class RoomDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public List<RoomWithResourceDTO> RoomResource { get; set; }

    public RoomDTO(int id, string name, int capacity, List<RoomWithResourceDTO> roomResource)
    {
        Id = id;
        Name = name;
        Capacity = capacity;
        RoomResource = roomResource;
    }
}
