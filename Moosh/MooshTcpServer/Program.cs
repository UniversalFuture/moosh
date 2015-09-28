using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using M = Moosh.Moosh;

namespace MooshTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var log = M.Logs("log.txt"))
            {
                M.Tcp.ServerSync(new IPEndPoint(IPAddress.Loopback, 1337), client =>
                {
                    Console.WriteLine($"New connection from {client.Client.RemoteEndPoint}!");
                    log.Write($"New connection from {client.Client.RemoteEndPoint}!");
                });
            }
        }
    }
}
