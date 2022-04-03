using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Server");

            var tcpListener = new TcpListener(IPAddress.Any, 8000);
            Console.WriteLine("Press enter to start server");
            Console.ReadLine();

            tcpListener.Start();
            Console.WriteLine($"Server started succesfully! {tcpListener.Server.LocalEndPoint}");

            Console.WriteLine("Waiting incoming connection...");
            TcpClient client = tcpListener.AcceptTcpClient();

            Console.WriteLine($"Client {client.Client.RemoteEndPoint} connected succesfully!");

            Console.WriteLine("Waiting for text messages...");
            NetworkStream stream = client.GetStream();
            var sr = new StreamReader(stream);
            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine("client >> " + message);

            }


            Console.ReadLine();
        }
    }
}
