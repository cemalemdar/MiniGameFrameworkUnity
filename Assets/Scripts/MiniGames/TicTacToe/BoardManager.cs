using UnityEngine;

namespace TicTacToe.Game
{
    public enum CellState { Empty, X, O }

    public class BoardManager : MonoBehaviour
    {
        private Cell[,] board;
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private float cellSize;
        [SerializeField] private int size = 3;

        public Cell[,] Board => board;

        public void Awake()
        {
            board = new Cell[size, size];
            GenerateCells();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }

        public void GenerateCells()
        {
            Vector2Int currentCellPosition = Vector2Int.zero;
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    currentCellPosition.x = column;
                    currentCellPosition.y = row;
                    Cell spawnedCell = SpawnCell(GetCellWorldPosition(currentCellPosition));
                    spawnedCell.cellPosition = currentCellPosition;
                }
            }
        }

        private Vector3 GetCellWorldPosition(Vector2Int cellPosition)
        {
            // World Position of (0,0)
            Vector3 worldPosition = transform.position;
            worldPosition.x -= (size - 1) / 2f * cellSize;
            worldPosition.y -= (size - 1) / 2f * cellSize;


            worldPosition.x += cellSize * cellPosition.x;
            worldPosition.y += cellSize * cellPosition.y;
            return worldPosition;
        }

        private Cell SpawnCell(Vector3 spawnPosition)
        {
            GameObject spawnedCellObject = Instantiate(cellPrefab.gameObject, spawnPosition, Quaternion.identity);
            Cell cell = spawnedCellObject.GetComponent<Cell>();
            return cell;
        }

        public bool PlaceMark(int row, int col, CellState mark)
        {
            Cell cell = board[row, col];
            if (cell.CurrentCellState != CellState.Empty) return false;
            cell.Mark(mark);
            return true;
        }

        public Cell GetCell(int row, int col)
        {
            return board[row, col];
        }

        public void ClearBoard()
        {
            for (int row = 0; row < size; row++)
                for (int column = 0; column < size; column++)
                    board[row, column].Mark(CellState.Empty);
        }

        public CellState[,] GetBoardSnapshot()
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);
            var snapshot = new CellState[width, height];
            for (int row = 0; row < size; row++)
                for (int column = 0; column < size; column++)
                    snapshot[column, row] = board[column, row].CurrentCellState;

            return snapshot;
        }
    }
}

