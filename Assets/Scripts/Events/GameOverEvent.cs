namespace GFrame.Events
{
    public class GameOverEvent : CustomEvent
    {
        public bool isGameWon;
        public static GameOverEvent Create(bool isGameWon)
        {
            GameOverEvent gameOverEvent = new GameOverEvent();
            gameOverEvent.isGameWon = isGameWon;
            return gameOverEvent;
        }
    }
}

