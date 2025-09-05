using Managers;
using Events;
using TicTacToeLogic;
using System.Collections.Generic;
using Data;

namespace Games
{
    public class TicTacToeGame : BaseGame
    {
        private BoardManager board;
        private TurnManager<CellState> turns;
        private WinChecker checker;
        private TicTacToeSave gameSaveData;

        protected override void OnInitialize()
        {
            board = new BoardManager(3);
            turns = new TurnManager<CellState>(new List<CellState> { CellState.X, CellState.O });
            checker = new WinChecker();

            context.UIManager.SetTitle("TicTacToe");
        }

        protected override void OnStartGame()
        {
            board.ClearBoard();
        }

        protected override void OnEndGame()
        {
            // Save progress example
            
             // or Losses/Draws depending
            context.SaveManager.Save();
        }

        public void HandleMove(int row, int col)
        {
            if (isGameOver) return;
            if (!board.PlaceMark(row, col, turns.CurrentTurn)) return;

            if (checker.CheckWin(GetBoard(), turns.CurrentTurn))
            {
                gameSaveData.Wins += 1;
                EventManager.Send(GameOverEvent.Create(true));
                EndGame();
                return;
            }

            if (checker.CheckDraw(GetBoard()))
            {
                gameSaveData.Draws += 1;
                EventManager.Send(GameOverEvent.Create(false));

                EndGame();
                return;
            }

            turns.NextTurn();
        }

        private CellState[,] GetBoard() =>
            (CellState[,])board.GetType()
                .GetField("board", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(board);
    } 
}

