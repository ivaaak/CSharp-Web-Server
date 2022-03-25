using HTTP_Server_Basic.HTTP;

namespace HTTP_Server_Basic.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse() 
            : base(StatusCode.BadRequest)
        {
        }

    }
}
