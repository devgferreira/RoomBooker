namespace RoomBooker.Application.DTO.Resource
{
    public class ResourceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ResourceDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
