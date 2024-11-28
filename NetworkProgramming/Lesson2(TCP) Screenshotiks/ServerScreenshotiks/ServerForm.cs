using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ScreenshotiksServer
{
    public partial class ServerForm : Form
    {
        private TcpListener _listener;
        private Thread _listenerThread;
        private bool _isRunning;
        private const int Port = 8088;
        private int _screenshotDelay = 2000;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (_isRunning) return;

            _isRunning = true;
            _listenerThread = new Thread(StartServer);
            _listenerThread.Start();
            UpdateStatus("Server is running...");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            _listener?.Stop();
            _listenerThread?.Join();
            UpdateStatus("Server stopped.");
        }

        private void StartServer()
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
            _listener.Start();

            while (_isRunning)
            {
                try
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    if (_isRunning)
                    {
                        UpdateStatus($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (var stream = client.GetStream())
                {
                    UpdateStatus("Client connected.");
                    while (_isRunning)
                    {
                        stream.WriteByte(1);

                        byte[] sizeBuffer = new byte[4];
                        int bytesRead = stream.Read(sizeBuffer, 0, sizeBuffer.Length);
                        if (bytesRead == 0) break;

                        int imageSize = BitConverter.ToInt32(sizeBuffer, 0);

                        byte[] imageBuffer = new byte[imageSize];
                        int totalBytesRead = 0;
                        while (totalBytesRead < imageSize)
                        {
                            bytesRead = stream.Read(imageBuffer, totalBytesRead, imageSize - totalBytesRead);
                            if (bytesRead == 0) break;
                            totalBytesRead += bytesRead;
                        }

                        DisplayScreenshot(imageBuffer);

                        Thread.Sleep(_screenshotDelay);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Client error: {ex.Message}");
            }
            finally
            {
                client.Close();
                UpdateStatus("Client disconnected." + (_isRunning ? "Server is working." : "Server is stopped"));
            }
        }

        private void DisplayScreenshot(byte[] imageData)
        {
            Invoke((MethodInvoker)(() =>
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    ScreenshotPictureBox.Image = Image.FromStream(ms);
                }
            }));
        }

        private void UpdateStatus(string message)
        {
            Invoke((MethodInvoker)(() => StatusLabel.Text = message));
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ScreenshotPictureBox.Width = this.ClientSize.Width - 24;
            ScreenshotPictureBox.Height = (this.ClientSize.Height - 76);
            ScreenshotPictureBox.Location = new Point(12, 64);
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopButton_Click(sender, e);
        }
    }
}
