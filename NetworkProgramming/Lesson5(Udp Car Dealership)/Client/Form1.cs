using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private UdpClient _udpClient;
        private IPEndPoint _serverEndpoint;

        public Form1()
        {
            InitializeComponent();
            _udpClient = new UdpClient();
            _serverEndpoint = new IPEndPoint(IPAddress.Loopback, 12345);
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            string request = txtRequest.Text;
            byte[] requestBytes = Encoding.UTF8.GetBytes(request);
            _udpClient.Send(requestBytes, requestBytes.Length, _serverEndpoint);

            var responseBytes = _udpClient.Receive(ref _serverEndpoint);
            string response = Encoding.UTF8.GetString(responseBytes);

            DisplayResponse(response);
        }

        private void DisplayResponse(string response)
        {
            var lines = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            txtResponse.Clear();

            foreach (var line in lines)
            {
                if (line.Contains("Available: True"))
                {
                    txtResponse.SelectionColor = Color.Green;
                }
                else if (line.Contains("Available: False"))
                {
                    txtResponse.SelectionColor = Color.Red;
                }
                else
                {
                    txtResponse.SelectionColor = Color.Black;
                }

                txtResponse.AppendText(line + Environment.NewLine);
            }
            txtResponse.SelectionColor = Color.Black;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _udpClient.Close();
        }

        private void txtRequset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSendRequest_Click(sender, e);
            }
        }
    }
}
