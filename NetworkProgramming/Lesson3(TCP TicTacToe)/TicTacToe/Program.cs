using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using TicTacToeShared;

namespace TicTacToeServer
{
    public class Server
    {
        private TcpListener _listener;
        private bool _isRunning;
        private const int Port = 8088;
        private List<GameResult> _gameResults = new List<GameResult>();
        private Random _random = new Random();

        public void Start()
        {
            _isRunning = true;
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), Port);
            _listener.Start();
            Console.WriteLine("Server is running...");

            while (_isRunning)
            {
                TcpClient client = _listener.AcceptTcpClient();
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                bool isPlayerFirst = _random.Next(2) == 0;
                string response = isPlayerFirst ? "COMPUTER_FIRST" : "COMPUTER_FIRST";
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);

                string[][] board = new string[3][]
                {
                    new string[3],
                    new string[3],
                    new string[3]
                };

                if (!isPlayerFirst)
                {
                    var computerMove = GetComputerMove(board);
                    board[computerMove[_random.Next(3)]][computerMove[_random.Next(3)]] = "O";

                    var gameResult = new GameResult
                    {
                        FinalBoard = board,
                        Result = " Game continues",
                        GameOver = false
                    };
                    response = JsonConvert.SerializeObject(gameResult);
                    responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }

                while (true)
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] parts = request.Split('|');
                    int row = int.Parse(parts[1]) - 1;
                    int col = int.Parse(parts[2]) - 1;

                    if (!string.IsNullOrEmpty(board[row][col]))
                    {
                        var errorResult = new GameResult
                        {
                            Result = "Error: the cell is already occupied",
                            GameOver = false
                        };
                        response = JsonConvert.SerializeObject(errorResult);
                        responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        continue;
                    }

                    board[row][col] = "X";

                    if (CheckWin(board, "X"))
                    {
                        var result = new GameResult
                        {
                            FinalBoard = board,
                            Result = "Player X won",
                            GameOver = true
                        };
                        SaveGameResult(result);
                        response = JsonConvert.SerializeObject(result);
                        responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        break;
                    }

                    if (IsBoardFull(board))
                    {
                        var result = new GameResult
                        {
                            FinalBoard = board,
                            Result = "Draw",
                            GameOver = true
                        };
                        SaveGameResult(result);
                        response = JsonConvert.SerializeObject(result);
                        responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        break;
                    }

                    var move = GetComputerMove(board);
                    board[move[0]][move[1]] = "O";

                    if (CheckWin(board, "O"))
                    {
                        var result = new GameResult
                        {
                            FinalBoard = board,
                            Result = "Computer won",
                            GameOver = true
                        };
                        SaveGameResult(result);
                        response = JsonConvert.SerializeObject(result);
                        responseBytes = Encoding.UTF8.GetBytes(response);
                        stream.Write(responseBytes, 0, responseBytes.Length);
                        break;
                    }

                    var gameResult = new GameResult
                    {
                        FinalBoard = board,
                        Result = "Game continues",
                        GameOver = false
                    };
                    response = JsonConvert.SerializeObject(gameResult);
                    responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
            client.Close();
        }

        private bool CheckWin(string[][] board, string player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i][0] == player && board[i][1] == player && board[i][2] == player)
                    return true;
                if (board[0][i] == player && board[1][i] == player && board[2][i] == player)
                    return true;
            }
            if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
                return true;
            if (board[0][2] == player && board[1][1] == player && board[2][0] == player)
                return true;
            return false;
        }

        private bool IsBoardFull(string[][] board)
        {
            foreach (var row in board)
            {
                if (row.Contains(null))
                    return false;
            }
            return true;
        }

        private int[] GetComputerMove(string[][] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(board[i][j]))
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        private void SaveGameResult(GameResult result)
        {
            _gameResults.Add(result);
            string json = JsonConvert.SerializeObject(_gameResults, Formatting.Indented);
            File.WriteAllText("game_results.json", json);
        }

        public void Stop()
        {
            _isRunning = false;
            _listener.Stop();
            Console.WriteLine("Server stopped.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
