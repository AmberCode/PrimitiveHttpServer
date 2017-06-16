
using System.Net.Sockets;

namespace PrimitiveHttpServer_Dev.RequestHandlers
{
    public interface IRequestHandler
    {
        /// <summary>
        /// Handle http request
        /// </summary>
        void Handle();
    }
}
