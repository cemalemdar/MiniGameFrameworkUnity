namespace GFrame.Games
{
    public abstract class BaseGame : IMiniGame
    {
        protected bool isGameOver;
        protected GameConfig gameConfig;

        /// <summary>
        /// Unique identifier for this game instance.
        /// </summary>

        public string GameId { get; private set; }

        public virtual void Initialize(GameConfig game)
        {
            isGameOver = false;
            gameConfig = game;

            OnInitialize();
        }

        public virtual void StartGame()
        {
            OnStartGame();
        }

        public virtual void EndGame()
        {
            if (isGameOver) return;
            isGameOver = true;

            OnEndGame();
        }

        public virtual void CleanUp()
        {
        }

        public virtual void Restart()
        {
            if(!isGameOver) EndGame();
            Initialize(gameConfig);
            StartGame();
        }

        // Hooks for child classes
        protected abstract void OnInitialize();
        protected abstract void OnStartGame();
        protected abstract void OnEndGame();
    }
}
