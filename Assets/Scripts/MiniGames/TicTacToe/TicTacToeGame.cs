using GFrame.Games;
using GFrame.Managers;
using GFrame.Events;
using GFrame;
using UnityEngine;
using TicTacToe.Data;
using System.Collections.Generic;
using TicTacToe.Events;

namespace TicTacToe.Game
{
    public class TicTacToeGame : BaseGame
    {
        [SerializeField] private BoardManager board;
        [SerializeField] private TurnManager<CellState> turnManager;
        [SerializeField] private WinChecker checker;
        [SerializeField] private TicTacToeSave gameSaveData;

        protected override void OnInitialize()
        {
            turnManager = new TurnManager<CellState>(new List<CellState>() { CellState.X, CellState.O });
            checker = new WinChecker();
            GFrameManagers.EventManager.Register<CellTappedEvent>(OnCellTapped);
        }

        protected override void OnStartGame()
        {
            GFrameManagers.UIManager.ShowPanel("TicTacToe");
            board.ClearBoard();
        }

        protected override void OnEndGame()
        {
            // Save progress example

            // or Losses/Draws depending
            GFrameManagers.SaveManager.Save();
        }

        private void OnCellTapped(CellTappedEvent ev)
        {
            HandleMove(ev.tappedCell.cellPosition);
        }

        public void HandleMove(Vector2Int cellPosition)
        {
            if (isGameOver) return;
            if (!board.PlaceMark(cellPosition.y, cellPosition.x, turnManager.CurrentPlayer)) return;

            if (checker.CheckWin(GetBoard(), turnManager.CurrentPlayer))
            {
                gameSaveData.Wins += 1;
                GFrameManagers.EventManager.Send(GameOverEvent.Create(true));
                //EventManager.Send(GameOverEvent.Create(true));
                EndGame();
                return;
            }

            if (checker.CheckDraw(GetBoard()))
            {
                gameSaveData.Draws += 1;
                GFrameManagers.EventManager.Send(GameOverEvent.Create(false));

                EndGame();
                return;
            }

            turnManager.NextTurn();
        }

        private CellState[,] GetBoard() => board.GetBoardSnapshot();
    } 
}

