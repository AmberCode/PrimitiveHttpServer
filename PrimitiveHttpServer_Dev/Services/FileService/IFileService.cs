
namespace PrimitiveHttpServer_Dev.Services.WebPageFileService
{
    public interface IFileService
    {
        /// <summary>
        /// Return web file as byte array
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        byte[] GetFile(string fileName);
    }
}
