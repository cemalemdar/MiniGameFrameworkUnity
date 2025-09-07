using Sirenix.OdinInspector;
using UnityEngine;

namespace GFrame.Games
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GFrame/Game Config", order = 0)]
    public class GameConfig : SerializedScriptableObject
    {
        [Header("Game Metadata")]
        [SerializeField] private string gameID = "UniqueGameID";
        [SerializeField] private string gameSceneName = "UniqueSceneName";
        [SerializeField] private IMiniGame minigame;
        [SerializeField] private string displayName = "Game Name";
        [TextArea] [SerializeField] private string description;

        public string GameID => gameID;
        public string DisplayName => displayName;
        public string Description => description;
        public IMiniGame Minigame => minigame;
        public string GameSceneName => gameSceneName;
    }
}
