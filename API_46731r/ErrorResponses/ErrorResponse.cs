using API_46731r.ErrorResponses.Abstractions;

namespace API_46731r.ErrorResponses
{
    public class ErrorResponse : IErrorResponse
    {
        public string Message { get; set; }

        public ErrorResponse(Exception ex)
        {
            Message = ex.Message;
        }
    }
}
