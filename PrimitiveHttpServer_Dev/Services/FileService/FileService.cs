
using System.Text;

namespace PrimitiveHttpServer_Dev.Services.WebPageFileService
{
    public class FileService : IFileService
    {
        /// <summary>
        /// Read the file content into the stream and return byte array
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public byte[] GetFile(string fileName)
        {
            //TODO: find the file and return as byte array
            //Prototype
            if (string.IsNullOrEmpty(fileName))
            {
                //Try to find index/default web page
                return Encoding.ASCII.GetBytes(@"<html>
                <body>
                <h1>Pirminis internetinis puslapis.</h1>
                <body>
                </html>");
            }

            //Find web page file
            return Encoding.ASCII.GetBytes(@"<html>
            <body>
            <h1>Pagal kliento uzklausa</h1>
            <body>
            </html>");
        }
    }
}
