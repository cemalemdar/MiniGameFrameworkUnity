using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class TurnManager<TPlayer>
    {
        private readonly List<TPlayer> players;
        private int currentIndex;

        public TPlayer CurrentTurn => players[currentIndex];

        public TurnManager(List<TPlayer> players)
        {
            if (players == null || players.Count == 0)
                throw new System.ArgumentException("Players list cannot be empty.");

            this.players = players;
            currentIndex = 0;
        }

        public void NextTurn()
        {
            currentIndex = (currentIndex + 1) % players.Count;
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}

