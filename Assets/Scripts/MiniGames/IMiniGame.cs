
namespace Games
{
    public interface IMiniGame
    {
        void Initialize(GameContext context);
        void StartGame();
        void EndGame();
        void CleanUp();
        void Restart();
    }
}
