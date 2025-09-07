using GFrame.Managers;

namespace GFrame.Games
{
    public class GameContext
    {
        public IEventManager EventManager { get; }
        public ISaveManager SaveManager { get; }
        public IUIManager UIManager { get; }
        public ISceneManager SceneManager { get; }

        public int PlayerProfileId { get; }

        public GameContext(IEventManager eventManager,
                           ISaveManager saveManager,
                           IUIManager uiManager,
                           ISceneManager sceneManager,
                           int playerProfileId = 0)
        {
            EventManager = eventManager;
            SaveManager = saveManager;
            UIManager = uiManager;
            SceneManager = sceneManager;
            PlayerProfileId = playerProfileId;
        }
    }
}
