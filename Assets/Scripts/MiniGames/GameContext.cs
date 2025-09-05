using Events;
using Managers;

namespace Games
{
    public class GameContext
    {
        // Core Systems
        public EventManager EventManager { get; private set; }
        public SaveManager SaveManager { get; private set; }
        public UIManager UIManager { get; private set; }
        public AsyncSceneManager SceneManager { get; private set; }

        // Game Metadata
        //public GameConfig Config { get; private set; }
        //public string GameId => Config.GameId;
        //public string GameName => Config.DisplayName;

        // Player State
        public int PlayerProfileId { get; private set; } // player id

        public GameContext(EventManager eventManager , SaveManager saveManager,
                           UIManager uiManager, AsyncSceneManager asyncSceneManager
                           /*,GameConfig config, int profileId = 0*/)
        {
            EventManager = eventManager;
            SaveManager = saveManager;
            UIManager = uiManager;
            SceneManager = asyncSceneManager;
            //Config = config;
        }
    }
}
