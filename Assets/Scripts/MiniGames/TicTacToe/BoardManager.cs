using UnityEngine;

namespace TicTacToeLogic
{
    public enum CellState { Empty, X, O }

    public class BoardManager 
    {
        private CellState[,] board;
        private int size;

        public BoardManager(int size = 3)
        {
            this.size = size;
            board = new CellState[size, size];
            ClearBoard();
        }

        public bool PlaceMark(int row, int col, CellState mark)
        {
            if (board[row, col] != CellState.Empty) return false;
            board[row, col] = mark;
            return true;
        }

        public CellState GetCell(int row, int col)
        {
            return board[row, col];
        }

        public void ClearBoard()
        {
            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    board[r, c] = CellState.Empty;
        }
    }
}

