using GFrame.Data;
using UnityEngine;

namespace TicTacToe.Data
{
    [System.Serializable]
    public class TicTacToeSave : IGameSaveData
    {
        public int Wins;
        public int Losses;
        public int Draws;

        public string DumpJSON()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}

