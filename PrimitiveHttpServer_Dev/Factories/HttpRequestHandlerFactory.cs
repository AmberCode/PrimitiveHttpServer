using PrimitiveHttpServer_Dev.Enums;
using PrimitiveHttpServer_Dev.RequestHandlers;
using PrimitiveHttpServer_Dev.Services.HttpProtocolService;
using PrimitiveHttpServer_Dev.Services.WebPageFileService;
using System.Net.Sockets;
using System.Text;

namespace PrimitiveHttpServer_Dev.Factories
{
    /// <summary>
    /// Create handler by request method
    /// </summary>
    public class HttpRequestHandlerFactory
    {
        public static IRequestHandler GetHandler(Socket socket)
        {
            var requestBuffer = new byte[1024];
            socket.Receive(requestBuffer, requestBuffer.Length, SocketFlags.None);

            var requestString = Encoding.ASCII.GetString(requestBuffer);

            var requestMethod = GetRequestMethod(requestString);

            if (requestMethod == HttpRequestMethod.Get)
            {
                return new GetRequestHandler(socket, requestBuffer, new FileService(), new HttpProtocolService());
            }

            return new NullRequestHandler(socket, new HttpProtocolService());
        }

        private static HttpRequestMethod GetRequestMethod(string request)
        {
            if (string.IsNullOrEmpty(request))
            {
                return HttpRequestMethod.Undefined;
            }

            if (request.Substring(0, 3) == "GET")
            {
                return HttpRequestMethod.Get;
            }

            return HttpRequestMethod.Undefined;
        }
    }
}
