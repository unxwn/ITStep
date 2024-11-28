using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ScreenshotiksServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverIp = "127.0.0.1";
            int serverPort = 8088;

            while (true)
            {
                try
                {
                    Console.WriteLine("Attempting to connect to the server...");
                    using (TcpClient client = new TcpClient(serverIp, serverPort))
                    using (NetworkStream stream = client.GetStream())
                    {
                        Console.WriteLine("Connected to the server.");

                        while (client.Connected)
                        {
                            try
                            {
                                int command = stream.ReadByte();
                                if (command == -1)
                                    throw new IOException("Disconnected from server.");

                                if (command == 1)
                                {
                                    byte[] screenshot = CaptureScreenshot();
                                    byte[] sizeBuffer = BitConverter.GetBytes(screenshot.Length);

                                    stream.Write(sizeBuffer, 0, sizeBuffer.Length);
                                    stream.Write(screenshot, 0, screenshot.Length);

                                    Console.WriteLine("Screenshot sent.");
                                }
                            }
                            catch (IOException)
                            {
                                Console.WriteLine("Connection lost. Attempting to reconnect...");
                                break;
                            }
                        }
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("Server is not available. Retry? (y/n):");
                    string answer = Console.ReadLine()?.ToLower();

                    if (answer == "n")
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                System.Threading.Thread.Sleep(2000);
            }
        }

        private static byte[] CaptureScreenshot()
        {
            using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }
    }
}