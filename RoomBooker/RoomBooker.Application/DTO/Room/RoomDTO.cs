namespace RoomBooker.Application.DTO.Room;

public class RoomDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }

    public RoomDTO(int id, string name, int capacity)
    {
        Id = id;
        Name = name;
        Capacity = capacity;
    }
}
