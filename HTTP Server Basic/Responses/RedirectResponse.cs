using HTTP_Server_Basic.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Server_Basic.Responses
{
    public class RedirectResponse : Response
    {
        public RedirectResponse(string location) 
            : base(StatusCode.Found)
        {
            Headers.Add(Header.Location, location);
        }
    }
}
