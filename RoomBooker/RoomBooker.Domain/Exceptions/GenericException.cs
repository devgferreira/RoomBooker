using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooker.Domain.Exceptions
{
    public class GenericException : Exception
    {
        public ExceptionResponse Response { get; }
        public object ExceptionResponse { get; set; }

        public GenericException(ExceptionResponse response)
            : base(response.Message)
        {
            Response = response;
        }
    }
}
