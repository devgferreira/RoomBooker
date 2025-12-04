using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooker.Application.DTO.Room
{
    public class RoomWithResourceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public RoomWithResourceDTO(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
