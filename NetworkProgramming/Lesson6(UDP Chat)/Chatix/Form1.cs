using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Chatix
{
    public partial class Form1 : Form
    {
        private UdpClient udpClient;
        private IPAddress multicastAddress;
        private const int PORT = 5000;

        private const int MAX_MESSAGE_SIZE = 1024;

        public Form1()
        {
            InitializeComponent();
            InitializeNetworking();

            BeginReceiveMessages();
        }

        private void InitializeNetworking()
        {
            try
            {
                multicastAddress = IPAddress.Parse("239.0.0.1");

                udpClient = new UdpClient();

                udpClient.Client.SetSocketOption(
                    SocketOptionLevel.Socket,
                    SocketOptionName.ReuseAddress,
                    true
                );

                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));

                udpClient.JoinMulticastGroup(multicastAddress);

                UpdateStatus("Connected to multicast group");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing network: {ex.Message}");
            }
        }

        private void BeginReceiveMessages()
        {
            try
            {
                udpClient.BeginReceive(ReceiveCallback, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting receive: {ex.Message}");
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, PORT);

                byte[] data = udpClient.EndReceive(ar, ref remoteEP);
                string message = Encoding.UTF8.GetString(data);

                UpdateChatWindow(message);

                BeginReceiveMessages();
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving message: {ex.Message}");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textUsername.Text))
            {
                MessageBox.Show("Please enter a username");
                return;
            }

            if (string.IsNullOrWhiteSpace(richTextBoxMsg.Text))
            {
                return;
            }

            try
            {
                string message = $"{textUsername.Text}: {richTextBoxMsg.Text}";
                byte[] data = Encoding.UTF8.GetBytes(message);

                udpClient.Send(
                    data,
                    data.Length,
                    new IPEndPoint(multicastAddress, PORT)
                );

                richTextBoxMsg.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        private void UpdateChatWindow(string message)
        {
            if (richTextBoxDialog.InvokeRequired)
            {
                richTextBoxDialog.Invoke(new Action<string>(UpdateChatWindow), message);
                return;
            }

            richTextBoxDialog.AppendText(message + Environment.NewLine);
        }

        private void UpdateStatus(string status)
        {
            if (richTextBoxDialog.InvokeRequired)
            {
                richTextBoxDialog.Invoke(new Action<string>(UpdateStatus), status);
                return;
            }

            richTextBoxDialog.AppendText($"[System] {status}{Environment.NewLine}");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (udpClient != null)
            {
                try
                {
                    udpClient.DropMulticastGroup(multicastAddress);
                    udpClient.Close();
                }
                catch
                {

                }
            }
        }
    }
}
