using Games;

namespace Events
{
    public class LoadSceneEvent : CustomEvent
    {
        public GameType gameType;
        public static LoadSceneEvent Create(GameType gameType)
        {
            LoadSceneEvent loadSceneEvent = new LoadSceneEvent();
            loadSceneEvent.gameType = gameType;
            return loadSceneEvent;
        }
    }
}

