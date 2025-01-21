using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using TicTacToeShared;

namespace TicTacToeClient
{
    public class Client
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private string[][] _board = new string[3][]
        {
            new string[3],
            new string[3],
            new string[3]
        };
        private bool _gameOver;

        public void Connect(string serverIp, int port)
        {
            _client = new TcpClient(serverIp, port);
            _stream = _client.GetStream();
            Console.WriteLine("Connected to server.");
        }

        public void Play()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = _stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            if (response == "COMPUTER_FIRST")
            {
                Console.WriteLine("Computer goes first.");
                bytesRead = _stream.Read(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                ProcessServerResponse(response);
            }
            else
            {
                Console.WriteLine("You go first.");
            }

            while (true)
            {

                Console.WriteLine("Enter row and col (e.g. 1 2):");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                int row = int.Parse(parts[0]);
                int col = int.Parse(parts[1]);

                string request = $"MOVE|{row}|{col}";
                byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                _stream.Write(requestBytes, 0, requestBytes.Length);

                bytesRead = _stream.Read(buffer, 0, buffer.Length);
                response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                ProcessServerResponse(response);

                if (_gameOver)
                {
                    break;
                }
            }
        }

        private void ProcessServerResponse(string response)
        {
            var result = JsonConvert.DeserializeObject<GameResult>(response);

            if (result.Result == "Error: the cell is already occupied")
            {
                Console.WriteLine(result.Result);
                return;
            }

            _board = result.FinalBoard;
            DisplayBoard();

            if (result.GameOver)
            {
                Console.WriteLine(result.Result);
                _gameOver = true;
            }
        }

        private void DisplayBoard()
        {
            Console.WriteLine("Current field:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write((_board[i][j] ?? "_") + " ");
                }
                Console.WriteLine();
            }
        }

        public void Disconnect()
        {
            _stream.Close();
            _client.Close();
            Console.WriteLine("Disconnected from server.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Connect("127.0.0.1", 8088);
            client.Play();
            client.Disconnect();
        }
    }
}
