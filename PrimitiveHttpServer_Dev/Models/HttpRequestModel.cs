using PrimitiveHttpServer_Dev.Enums;

namespace PrimitiveHttpServer_Dev.Models
{
    /// <summary>
    /// Parent request model
    /// </summary>
    public abstract class HttpRequestModel
    {
        public HttpRequestMethod HttpRequestMethod { get; set; }
        public string FileName { get; set; }
        public string UserAgent { get; set; }
        public string Accept { get; set; }
        public string AcceptLanguage { get; set; }
        public string AcceptEncoding { get; set; }

    }
}
