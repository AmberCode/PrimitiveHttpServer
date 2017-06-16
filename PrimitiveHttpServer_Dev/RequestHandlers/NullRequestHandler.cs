
using PrimitiveHttpServer_Dev.Services.HttpProtocolService;
using System;
using System.Net.Sockets;

namespace PrimitiveHttpServer_Dev.RequestHandlers
{
    /// <summary>
    /// Http method not implemented handler
    /// </summary>
    public class NullRequestHandler : IRequestHandler
    {
        private readonly IHttpProtocolService _httpProtocolService;
        private readonly Socket _socket;

        public NullRequestHandler(Socket socket, IHttpProtocolService httpProtocolService)
        {
            _socket = socket;
            _httpProtocolService = httpProtocolService;
        }
        public void Handle()
        {
            try
            {
                var responseHeader = _httpProtocolService.CreateResponseHeader(Enums.HttpResponseStatus.MethodNotAllowed, 0, "text/html");
                              
                SendResponse(responseHeader);
            }
            catch (Exception ex)
            {
                //log
            }
            finally
            {
                if (_socket.Connected)
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Close();
                }
            }
        }

        private void SendResponse(byte[] data)
        {
            try
            {
                var noOfBytes = 0;
                if ((noOfBytes = _socket.Send(data, data.Length, 0)) == -1)
                {
                    //log failed
                }
                else
                {
                    //log success;
                }
            }
            catch (Exception ex)
            {
                //log ex
            }
        }
    }
}
