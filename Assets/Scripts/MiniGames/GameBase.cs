
namespace Games
{
    public abstract class BaseGame : IMiniGame
    {
        protected GameContext context { get; private set; }
        protected bool isGameOver;

        public virtual void Initialize(GameContext context)
        {
            this.context = context;
            isGameOver = false;
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
            Initialize(context);
            StartGame();
        }

        // Hooks for child classes
        protected abstract void OnInitialize();
        protected abstract void OnStartGame();
        protected abstract void OnEndGame();

        
    }
}


