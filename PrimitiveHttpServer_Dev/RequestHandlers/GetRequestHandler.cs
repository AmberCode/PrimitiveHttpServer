
using PrimitiveHttpServer_Dev.Enums;
using PrimitiveHttpServer_Dev.Services.HttpProtocolService;
using PrimitiveHttpServer_Dev.Services.WebPageFileService;
using System;
using System.Net.Sockets;

namespace PrimitiveHttpServer_Dev.RequestHandlers
{
    /// <summary>
    /// HTTP GET request handler
    /// </summary>
    public class GetRequestHandler : IRequestHandler
    {
        private readonly IFileService _fileService;
        private readonly IHttpProtocolService _httpProtocolService;
        private readonly Socket _socket;
        private readonly byte[] _received;

        public GetRequestHandler(Socket socket, byte[] received, IFileService fileService, 
            IHttpProtocolService httpProtocolService)
        {
            _socket = socket;
            _received = received;
            _fileService = fileService;
            _httpProtocolService = httpProtocolService;
        }
        
        public void Handle()
        {
            try
            {
                var responseStatus = HttpResponseStatus.Ok;
                //Get file name from request or default
                var fileName = _httpProtocolService.GetFileName(_received);

                //Get web page file
                var responseBody = _fileService.GetFile(fileName);

                if (responseBody.Length == 0) responseStatus = HttpResponseStatus.NotFound;

                var contentType = _httpProtocolService.GetContentType(fileName);

                //Create response header
                var responseHeader = _httpProtocolService.CreateResponseHeader(responseStatus, responseBody.Length, contentType);

                //Merge header and body
                var response = new byte[responseHeader.Length + responseBody.Length];
                responseHeader.CopyTo(response, 0);
                responseBody.CopyTo(response, responseHeader.Length);

                //Send response 
                SendResponse(response);
            }
            catch(Exception ex)
            {
                //log
                //Send Internal Server Error
                var errorHeader = _httpProtocolService.CreateResponseHeader(HttpResponseStatus.InternalServerError, 0, "text/plain");
                SendResponse(errorHeader);    
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
