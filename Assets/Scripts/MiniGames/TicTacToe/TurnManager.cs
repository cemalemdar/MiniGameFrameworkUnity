using System.Collections.Generic;
using TicTacToe.Events;
namespace GFrame.Managers
{
    public class TurnManager<TPlayer>
    {
        private List<TPlayer> players;
        private int currentPlayerIndex;

        public TPlayer CurrentPlayer => players[currentPlayerIndex];

        public TurnManager(List<TPlayer> players)
        {
            this.players = players;
            currentPlayerIndex = 0;
        }

        public void NextTurn()
        {
            currentPlayerIndex++;
            currentPlayerIndex = currentPlayerIndex >= players.Count ? 0 : currentPlayerIndex;

            EventManager.SendEvent(TurnChangedEvent.Create());
        }

        public void Reset()
        {
            currentPlayerIndex = 0;
        }
    }
}

