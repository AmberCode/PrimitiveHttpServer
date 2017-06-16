using PrimitiveHttpServer_Dev.Server;
using System;

namespace PrimitiveHttpServer_Dev
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new PrimitiveHttpServer().Start();
            }
            catch(Exception ex)
            {
                //log ex
            }

            Console.ReadLine();
        }
    }
}
