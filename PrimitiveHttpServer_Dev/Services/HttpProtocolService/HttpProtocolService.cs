using PrimitiveHttpServer_Dev.Enums;
using System;
using System.Text;

namespace PrimitiveHttpServer_Dev.Services.HttpProtocolService
{
    public class HttpProtocolService : IHttpProtocolService
    {
        public string GetFileName(byte[] httpRequest)
        {
            //Parse request to get filename
            // string requestString = Encoding.ASCII.GetString(httpRequest);
            
            return string.Empty;
        }
        public string GetContentType(string fileName)
        {
            //TODO: just for prototype
            return "text/html";

            //if (fileName.EndsWith("html") || fileName.EndsWith("htm"))
            //{
            //    return "text/html";
            //}
            //else if (fileName.EndsWith("gif"))
            //{
            //    return "image/gif";
            //}
            //else if (fileName.EndsWith("js"))
            //{
            //    return "text/javascript; charset=UTF-8";
            //}
            //else if (fileName.EndsWith("css"))
            //{
            //    return "text/css";
            //}
        }
        public byte[] CreateResponseHeader(HttpResponseStatus httpResponseStatus, int contentLength, string contentType)
        {
            var header = new StringBuilder();
            
            header.Append(GetResponseStatusLine(httpResponseStatus));
            header.Append($"Date: {DateTime.Now.ToUniversalTime():ddd, dd MMM yyyy HH:mm:ss \'GMT\'}\r\n");
            header.Append("Server: PrimitiveServer\r\n");
            header.Append("Content-Length: " + contentLength + "\r\n");
            header.Append("Content-Type: " + contentType + "\r\n");
            header.Append("Connection: Closed\r\n");
            header.Append("\r\n");
            
            return Encoding.ASCII.GetBytes(header.ToString());
        }

        private string GetResponseStatusLine(HttpResponseStatus httpResponseStatus)
        {
            switch (httpResponseStatus)
            {
                case HttpResponseStatus.Ok:
                    return "HTTP/1.1 200 OK\r\n";
                case HttpResponseStatus.MethodNotAllowed:
                    return "HTTP/1.1 405 Method Not Allowed\r\n";
                default:
                    return "HTTP/1.1 500 Error\r\n";
            }
        }    
    }
}
