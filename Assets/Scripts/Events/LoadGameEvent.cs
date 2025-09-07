using GFrame.Games;

namespace GFrame.Events
{
    public class LoadGameEvent : CustomEvent
    {
        public GameConfig gameConfig;
        public static LoadGameEvent Create(GameConfig gameConfig)
        {
            LoadGameEvent loadGameEvent = new LoadGameEvent();
            loadGameEvent.gameConfig = gameConfig;
            return loadGameEvent;
        }
    }
}

