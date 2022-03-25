using HTTP_Server_Basic.HTTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Server_Basic.Responses
{
    public class TextFileResponse : Response
    {
        public string FileName { get; set; }

        public TextFileResponse(string fileName) 
            : base(StatusCode.OK)
        {
            FileName = fileName;

            Headers.Add(Header.ContentType, ContentType.PlainText)
        }

        public override string ToString()
        {
            if (File.Exists(FileName))
            {
                Body = File.ReadAllText(FileName);  
                var fileBytesCount = new FileInfo(FileName).Length;
                Headers.Add(Header.ContentLength, fileBytesCount.ToString());
                Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{FileName}\"");
            }

            return base.ToString();
        }
    }
}
