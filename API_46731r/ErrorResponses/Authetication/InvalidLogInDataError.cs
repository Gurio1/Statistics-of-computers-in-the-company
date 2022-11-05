using API_46731r.Domain.Exceptions;
using API_46731r.Domain.Exceptions.Authentication;
using API_46731r.ErrorResponses.Abstractions;

namespace API_46731r.ErrorResponses.Authetication
{
    public class InvalidLogInDataError : IErrorResponse
    {
        public Errors Errors { get; set; } = new Errors();

        public InvalidLogInDataError(InvalidEmailExeption ex)
        {
            Errors.AddEmailError(ex.Message);
        }
        public InvalidLogInDataError(InvalidPasswordExeption ex)
        {
            Errors.AddPasswordError(ex.Message);
        }
    }
}
