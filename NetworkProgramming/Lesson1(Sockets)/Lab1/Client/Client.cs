using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using ProductNamespace;
using System.Net;

namespace ClientNamespace
{
    class Client
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8088);
                clientSocket.Connect(serverEndPoint);
                Console.WriteLine("Connected to server.");

                while (true)
                {
                    Console.Write("Enter product ID: ");
                    string productId = Console.ReadLine();

                    byte[] data = Encoding.UTF8.GetBytes(productId);
                    clientSocket.Send(data);

                    byte[] buffer = new byte[256];
                    int receivedLength;
                    string receivedData = "";

                    do
                    {
                        receivedLength = clientSocket.Receive(buffer);
                        receivedData += Encoding.UTF8.GetString(buffer, 0, receivedLength);
                    }
                    while (receivedLength > 0 && clientSocket.Available > 0);

                    if (receivedData.StartsWith("{"))
                    {
                        Product product = JsonConvert.DeserializeObject<Product>(receivedData);
                        Console.WriteLine("Product found:");
                        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Manufacturer: {product.Manufacturer}");
                    }
                    else
                    {
                        Console.WriteLine(receivedData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
