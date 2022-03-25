using HTTP_Server_Basic.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Server_Basic.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text) 
            : base(text, ContentType.Html)
        {
        }
    }
}
