using PrimitiveHttpServer_Dev.Factories;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PrimitiveHttpServer_Dev.Server
{
    /// <summary>
    /// Primitive Http Server
    /// </summary>
    public class PrimitiveHttpServer : IHttpServer
    {
        public void Start()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            var listener = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(endPoint);
            //The maximum length of the pending connections queue - 2147483647
            listener.Listen(2147483647);

            Console.WriteLine("PrimitiveHttpServer has started. Type http://localhost:5000 in your browser");

            while (true)
            {
                try
                {
                    var socket = listener.Accept();

                    if (socket.Connected)
                    {
                        new Task(() => ProcessRequest(socket)).Start();
                    }
                }
                catch(Exception ex)
                {
                    //log ex
                }
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        private static void ProcessRequest(Socket socket)
        {
            var requestHandler = HttpRequestHandlerFactory.GetHandler(socket);
            requestHandler.Handle();   
        }
    }
}
