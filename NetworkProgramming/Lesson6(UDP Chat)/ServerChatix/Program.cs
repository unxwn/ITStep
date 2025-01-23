using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerChatix
{
    internal class Program
    {
        private static readonly IPAddress multicastAddress = IPAddress.Parse("224.5.5.5");
        private static readonly int multicastPort = 4567;
        private static readonly int serverPort = 5000;
        private static List<TcpClient> clients = new List<TcpClient>();

        static void Main()
        {
            TcpListener server = new TcpListener(IPAddress.Any, serverPort);
            server.Start();
            Console.WriteLine($"Server started on port {serverPort}");

            // Запуск потоку для прийому повідомлень
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Console.WriteLine("New client connected!");

                // Обробка клієнта в окремому потоці
                var clientThread = new System.Threading.Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private static void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {message}");
                    SendToMulticastGroup(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                clients.Remove(client);
                client.Close();
                Console.WriteLine("Client disconnected!");
            }
        }

        private static void SendToMulticastGroup(string message)
        {
            using (Socket multicastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                multicastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
                multicastSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(multicastAddress));

                IPEndPoint multicastEndpoint = new IPEndPoint(multicastAddress, multicastPort);
                byte[] data = Encoding.UTF8.GetBytes(message);
                multicastSocket.SendTo(data, multicastEndpoint);
            }
        }
    }
}
