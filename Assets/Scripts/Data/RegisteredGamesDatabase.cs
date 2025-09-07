using System.Collections.Generic;
using UnityEngine;
using GFrame.Games;
using Sirenix.OdinInspector;

namespace GFrame.Data
{
    [CreateAssetMenu(fileName = "RegisteredGames", menuName = "GFrame/Registered Games Database", order = 1)]
    public class RegisteredGamesDatabase : SerializedScriptableObject
    {

        /// <summary>
        /// Key: Game ID | Value: Mini Game
        /// </summary>
        [Tooltip("Key: Game ID | Value: Mini Game")]
        [SerializeField] private Dictionary<string, GameConfig> games;

        public Dictionary<string, GameConfig> Games => games;
    }
}
