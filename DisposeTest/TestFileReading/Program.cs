using System;
using System.Text;

namespace TestFileReading
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage : ReadFile <FileName>");
                return 1;
            }

            if (!System.IO.File.Exists(args[0]))
            {
                Console.WriteLine("File " + args[0] + " not found.");
                return 1;
            }

            byte[] buffer = new byte[128];

            using (FileReader fr = new FileReader())
            {
                if (fr.Open(args[0]))
                {

                    // Assume that an ASCII file is being read
                    ASCIIEncoding Encoding = new ASCIIEncoding();

                    int bytesRead;
                    do
                    {
                        bytesRead = fr.Read(buffer, 0, buffer.Length);
                        string content = Encoding.GetString(buffer, 0, bytesRead);
                        Console.Write("{0}", content);
                    }
                    while (bytesRead > 0);
                    return 0;
                }
                else
                {
                    Console.WriteLine("Failed to open requested file");
                    return 1;
                }
            }
        }
    }
}
