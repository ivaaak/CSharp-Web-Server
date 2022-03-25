using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP_Server_Basic.HTTP
{
    public class Response
    {
        public StatusCode StatusCode { get; init; }
         
        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public Action<Request, Response> PreRenderAction { get; protected set; }

        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
            Headers.Add(Header.Server, "SoftUni Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)StatusCode} {StatusCode}");

            foreach (var header in Headers)
            {
                result.AppendLine(header.ToString());
            }
            return result.ToString();
        }

    }
}
