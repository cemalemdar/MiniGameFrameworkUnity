using UnityEngine;

namespace TicTacToe.Game
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Transform xMark;
        [SerializeField] private Transform oMark;

        public Vector2Int cellPosition;

        private CellState currentCellState = CellState.Empty;
        public CellState CurrentCellState  => currentCellState;

        public void Mark(CellState cellState)
        {
            currentCellState = cellState;
            if (cellState == CellState.X)
            {
                xMark.gameObject.SetActive(true);
                oMark.gameObject.SetActive(false);
            }
            else if(cellState == CellState.X)
            {
                oMark.gameObject.SetActive(true);
                xMark.gameObject.SetActive(false);
            }
            else
            {
                xMark.gameObject.SetActive(false);
                oMark.gameObject.SetActive(false);
            }
        }
    }
}

