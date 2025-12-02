using RoomBooker.Domain.Exceptions;

namespace RoomBooker.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is GenericException exceptionResponse)
            {
                context.Response.StatusCode = exceptionResponse.Response.StatusCode;
                var response = new ExceptionResponse(exceptionResponse.Response.StatusCode, exceptionResponse.Message);
                return context.Response.WriteAsJsonAsync(response);
            }

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return context.Response.WriteAsJsonAsync(new ExceptionResponse(context.Response.StatusCode, ex.Message));
        }
    }
}
