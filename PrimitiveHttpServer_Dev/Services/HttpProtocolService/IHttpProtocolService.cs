using PrimitiveHttpServer_Dev.Enums;

namespace PrimitiveHttpServer_Dev.Services.HttpProtocolService
{
    public interface IHttpProtocolService
    {
        /// <summary>
        /// Get file name from request
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        string GetFileName(byte[] httpRequest);

        /// <summary>
        /// Create htttp response header
        /// </summary>
        /// <param name="httpResponseStatus"></param>
        /// <param name="contentLength"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        byte[] CreateResponseHeader(HttpResponseStatus httpResponseStatus, int contentLength, string contentType);

        /// <summary>
        /// Get content type by file type
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string GetContentType(string fileName);
    }
}
