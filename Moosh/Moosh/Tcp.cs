using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Moosh
{
    public static partial class Moosh
    {
        /// <summary>
        /// Helper methods to easily use TCP/IP.
        /// </summary>
        public static class Tcp
        {
            /// <summary>
            /// Asynchronously listens for, and handles, incoming TCP connections.
            /// </summary>
            /// <param name="endPoint">A local endpoint to listen on.</param>
            /// <param name="onConnect">A callback function to run on every incoming client.</param>
            public static void Server(IPEndPoint endPoint, Action<TcpClient> onConnect)
            {
                Async(() =>
                {
                    ServerSync(endPoint, onConnect);
                });
            }

            /// <summary>
            /// Synchronously listens for, and handles, incoming TCP connections.
            /// </summary>
            /// <param name="endPoint">A local endpoint to listen on.</param>
            /// <param name="onConnect">A callback function to run on every incoming client.</param>
            public static void ServerSync(IPEndPoint endPoint, Action<TcpClient> onConnect)
            {
                var listener = new TcpListener(endPoint);
                listener.Start();
                while (true)
                {
                    try
                    {
                        var client = listener.AcceptTcpClient();
                        onConnect(client);
                    }
                    catch
                    {
                        break;
                    }
                }
            }
        }
    }
}
