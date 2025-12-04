using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooker.Domain.Exceptions
{
    public class ExceptionResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ExceptionResponse(string code, string message)
        {
            Message = message;
        }

        public ExceptionResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ExceptionResponse()
        {
        }
    }
}
