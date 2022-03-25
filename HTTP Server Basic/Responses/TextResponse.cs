
using HTTP_Server_Basic.HTTP;
using System;

namespace HTTP_Server_Basic.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text, 
            Action<Request, Response> preRenderAction = null) 
            : base(text, ContentType.PlainText, preRenderAction)
        {

        }
    }
}
