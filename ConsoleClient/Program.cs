using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Client");

            var tcpClient = new TcpClient();
            Console.WriteLine("Press enter to connect to server");
            Console.ReadLine();

            tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8000);


            Console.WriteLine("Successfully connected");
            NetworkStream stream = tcpClient.GetStream();
            var sw = new StreamWriter(stream);

            while (true)
            {
                Console.Write(">> ");
                string messsage = Console.ReadLine();
                sw.WriteLine(messsage);
                sw.Flush();
            }
            
            

            Console.ReadLine();
        }
    }
}
