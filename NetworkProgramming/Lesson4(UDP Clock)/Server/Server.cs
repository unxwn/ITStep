using ReminderLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    internal class Server
    {
        static List<Reminder> reminders = new List<Reminder>();
        static UdpClient server;
        static string localIp = "127.0.0.1";
        static int serverPort = 8001;

        static void Main()
        {
            server = new UdpClient(new IPEndPoint(IPAddress.Parse(localIp), serverPort));
            Console.WriteLine("Server is running...");

            Thread reminderThread = new Thread(CheckReminders);
            reminderThread.IsBackground = true;
            reminderThread.Start();

            while (true)
            {
                IPEndPoint clientEndPoint = null;
                byte[] data = server.Receive(ref clientEndPoint);
                string request = Encoding.UTF8.GetString(data);

                if (request == "TIME")
                {
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");
                    byte[] response = Encoding.UTF8.GetBytes(currentTime);
                    server.Send(response, response.Length, clientEndPoint);
                    Console.WriteLine($"Sent time to {clientEndPoint}: {currentTime}");
                }
                else if (request == "REMINDERS")
                {
                    string reminderList = string.Join("\n", reminders);
                    byte[] response = Encoding.UTF8.GetBytes(reminderList);
                    server.Send(response, response.Length, clientEndPoint);
                    Console.WriteLine($"Sent reminders to {clientEndPoint}");
                }
                else if (request.StartsWith("ADD_REMINDER "))
                {
                    try
                    {
                        string[] parts = request.Substring(13).Split(new[] { ' ' }, 2);
                        DateTime time = DateTime.Parse(parts[0]);
                        string message = parts.Length > 1 ? parts[1] : "";
                        reminders.Add(new Reminder(time, message));
                        Console.WriteLine($"Added reminder: {time} {message}");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid reminder format received.");
                    }
                }
            }
        }

        static void CheckReminders()
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                List<Reminder> expiredReminders = new List<Reminder>();

                foreach (var reminder in reminders)
                {
                    if (reminder.IsTimeToRemind(now))
                    {
                        Console.WriteLine($"Reminder triggered: {reminder}");

                        // Broadcast reminder to all clients
                        byte[] data = Encoding.UTF8.GetBytes($"REMINDER {reminder.Message}");
                        server.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, 8002));

                        expiredReminders.Add(reminder);
                    }
                }

                foreach (var reminder in expiredReminders)
                {
                    reminders.Remove(reminder);
                }

                Thread.Sleep(1000); // Check every second
            }
        }
    }
}
