using Newtonsoft.Json;
using ProductNamespace;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace ServerNamespace
{
    class Program
    {
        private static List<Product> products = new List<Product>
    {
        new Product(1, "Laptop", 1200.50m, "Dell"),
        new Product(2, "Phone", 799.99m, "Samsung"),
        new Product(3, "Tablet", 399.99m, "Apple"),
    };

        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8088);
            serverSocket.Bind(endPoint);

            serverSocket.Listen(5);
            Console.WriteLine("Server started on port 8088. Waiting for connections...");

            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("Client connected.");

                byte[] buffer = new byte[256];
                int receivedLength;
                string receivedData = "";

                do
                {
                    receivedLength = clientSocket.Receive(buffer);
                    receivedData += Encoding.UTF8.GetString(buffer, 0, receivedLength);
                }
                while (receivedLength > 0 && clientSocket.Available > 0);

                int productId = int.Parse(receivedData);

                Console.WriteLine($"Received: {receivedData}");

                Product product = products.Find(p => p.Id == productId);

                string response;
                if (product != null)
                {
                    response = JsonConvert.SerializeObject(product);
                }
                else
                {
                    response = "Product not found";
                }

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                clientSocket.Send(responseBytes);
                Console.WriteLine($"Sent: {response}");

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
