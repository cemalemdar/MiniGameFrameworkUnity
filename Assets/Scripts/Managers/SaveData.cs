using System.Collections.Generic;
using Games;

namespace Data
{
    [System.Serializable]
    public class SaveData
    {
        public string userID;
        public Dictionary<GameType, string> gameProgress;
        // Key: gameId, Value: serialized JSON of that game's save object
        // Example: { "TicTacToe": "{ \"Wins\": 3, \"Losses\": 2 }" }

        public int coins;
        public string lastPlayedGame;

        public SaveData(string userID = "default user")
        {
            this.userID = userID;
            gameProgress = new Dictionary<GameType, string>();
            coins = 0;
            lastPlayedGame = string.Empty;
        }
    }
}
