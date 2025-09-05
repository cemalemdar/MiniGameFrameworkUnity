using Games;

namespace Events
{
    public class LoadGameEvent : CustomEvent
    {
        public GameType gameType;
        public static LoadGameEvent Create(GameType gameType)
        {
            LoadGameEvent loadGameEvent = new LoadGameEvent();
            loadGameEvent.gameType = gameType;
            return loadGameEvent;
        }
    }
}

