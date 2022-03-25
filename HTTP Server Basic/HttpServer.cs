using HTTP_Server_Basic.HTTP;
using HTTP_Server_Basic.Routing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Server_Basic
{
    public class HttpServer
    {
        private readonly IPAddress iPAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;


        public HttpServer(string _ipAddress, int _port, Action<IRoutingTable> routingTableConfiguration)
        {
            iPAddress = IPAddress.Parse(_ipAddress);
            port = _port;

            serverListener = new TcpListener(iPAddress, port);

            routingTableConfiguration(routingTable = new RoutingTable());
        }


        public HttpServer(int port, Action<IRoutingTable> routingTable) 
            : this("127.0.0.1", port, routingTable)
        {

        }
        public HttpServer(Action<IRoutingTable> routingTable)
           : this(8080, routingTable)
        {

        }

        public async Task Start()
        {
            serverListener.Start();
            System.Console.WriteLine($"Server is listening on port {port}");
            System.Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    var networkStream = connection.GetStream();

                    var requestText = await ReadRequest(networkStream);

                    Console.WriteLine(requestText);

                    var request = Request.Parse(requestText);

                    var response = routingTable.MatchRequest(request);

                    if(response.PreRenderAction != null)
                    {
                        response.PreRenderAction(request, response);
                    }

                    await WriteResponse(networkStream, "Hello World");

                    connection.Close();
                });
            }
        }



        private async Task WriteResponse(NetworkStream networkStream, string content)
        {
            int contentLength = Encoding.UTF8.GetByteCount(content);
            string response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length:{content.Length}
            
{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }


        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            byte[] buffer = new byte[1024];

            StringBuilder request = new StringBuilder();
            
            int totalBytes = 0;
            do
            {
                int bytesRead = await networkStream.ReadAsync(buffer, totalBytes, buffer.Length);
                totalBytes += bytesRead;

                if(totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request too large.");
                }

                request.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return request.ToString();
        }
    }
}
