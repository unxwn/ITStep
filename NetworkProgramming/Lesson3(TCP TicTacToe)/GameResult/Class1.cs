using System.Collections.Generic;

namespace TicTacToeShared
{
    public class GameResult
    {
        public string GameStartTime { get; set; }
        public string GameEndTime { get; set; }
        public string[][] FinalBoard { get; set; }
        public List<Move> Moves { get; set; }
        public string Result { get; set; }
        public bool GameOver { get; set; }
    }

    public class Move
    {
        public string Player { get; set; }
        public int[] MoveCoordinates { get; set; }
    }
}
