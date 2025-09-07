using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Data
{
    [System.Serializable]
    public class SaveData : IGameSaveData
    {
        public string userID;
        /// <summary>
        /// Key: Game ID | Value: game specific save data
        /// </summary>
        public Dictionary<string, IGameSaveData> gameProgress;

        public int coins;
        public string lastPlayedGame;

        public SaveData(string userID = "default user")
        {
            this.userID = userID;
            gameProgress = new Dictionary<string, IGameSaveData>();
            coins = 0;
            lastPlayedGame = string.Empty;
        }

        public string DumpJSON()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
