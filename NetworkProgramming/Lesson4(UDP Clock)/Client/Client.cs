using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ReminderLib;


namespace Client
{
    internal class Client
    {
        static void Main()
        {
            string serverIp = "127.0.0.1";
            int serverPort = 8001;
            int clientRequestPort = 8002;
            int clientReminderPort = 8003;

            UdpClient reminderClient = new UdpClient(clientReminderPort);
            UdpClient requestClient = new UdpClient(clientRequestPort);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

            Console.WriteLine("Client is running.");

            Thread listenThread = new Thread(() => ListenForReminders(reminderClient));
            listenThread.IsBackground = true;
            listenThread.Start();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Continuously receive time");
                Console.WriteLine("2. Receive time once");
                Console.WriteLine("3. View reminders");
                Console.WriteLine("4. Add a new reminder");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Receiving time continuously. Press Ctrl+C to stop.");
                        while (true)
                        {
                            requestClient.Send(Encoding.UTF8.GetBytes("TIME"), "TIME".Length, serverEndPoint);
                            IPEndPoint remoteEndPoint = null;
                            byte[] data = requestClient.Receive(ref remoteEndPoint);
                            string currentTime = Encoding.UTF8.GetString(data);
                            Console.WriteLine($"Current time: {currentTime}");
                            Thread.Sleep(1000);
                        }
                    case "2":
                        requestClient.Send(Encoding.UTF8.GetBytes("TIME"), "TIME".Length, serverEndPoint);
                        IPEndPoint remoteEP = null;
                        byte[] response = requestClient.Receive(ref remoteEP);
                        Console.WriteLine($"Current time: {Encoding.UTF8.GetString(response)}");
                        break;
                    case "3":
                        requestClient.Send(Encoding.UTF8.GetBytes("REMINDERS"), "REMINDERS".Length, serverEndPoint);
                        IPEndPoint remoteEndPointForReminders = null;
                        byte[] reminderData = requestClient.Receive(ref remoteEndPointForReminders);
                        Console.WriteLine($"Reminders:\n{Encoding.UTF8.GetString(reminderData)}");
                        break;
                    case "4":
                        Console.WriteLine("Enter new reminder (format: HH:mm:ss Message):");
                        string reminderInput = Console.ReadLine();
                        string addReminderRequest = $"ADD_REMINDER {reminderInput}";
                        requestClient.Send(Encoding.UTF8.GetBytes(addReminderRequest), addReminderRequest.Length, serverEndPoint);
                        Console.WriteLine("Reminder added.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ListenForReminders(UdpClient client)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] data = client.Receive(ref remoteEndPoint);
                string message = Encoding.UTF8.GetString(data);

                if (message.StartsWith("REMINDER "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{message.Substring(9)}");
                    Console.ResetColor();
                }
            }
        }
    }
}
