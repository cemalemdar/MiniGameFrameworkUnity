
namespace GFrame.Games
{
    public interface IMiniGame
    {
        void Initialize(GameConfig gameConfig);
        void StartGame();
        void EndGame();
        void CleanUp();
        void Restart();
    }
}
