using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooker.Domain.Entity.Room.Response
{
    public class RoomWithResourceResponse
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }
        public int RoomCapacity { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int ResourceCapacity { get; set; }

    }
}
