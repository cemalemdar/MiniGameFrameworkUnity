
namespace TicTacToeLogic
{
    public class WinChecker
    {
        public bool CheckWin(CellState[,] board, CellState player)
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (board[col, row] != player)
                        continue;

                    // Boundaries
                    bool canCheckRow = (col + 2 < width);
                    bool canCheckCol = (row + 2 < height);
                    bool canCheckMainDiag = (col + 2 < width && row + 2 < height);
                    bool canCheckAntiDiag = (col - 2 >= 0 && row + 2 < height);

                    // Row
                    bool rowWin = canCheckRow &&
                                  board[col + 1, row] == player &&
                                  board[col + 2, row] == player;

                    // Column ---
                    bool colWin = canCheckCol &&
                                  board[col, row + 1] == player &&
                                  board[col, row + 2] == player;

                    // Main diagonal (top-left → bottom-right) ---
                    bool diagWinMain = canCheckMainDiag &&
                                       board[col + 1, row + 1] == player &&
                                       board[col + 2, row + 2] == player;

                    // Anti diagonal (top-right → bottom-left) ---
                    bool diagWinAnti = canCheckAntiDiag &&
                                       board[col - 1, row + 1] == player &&
                                       board[col - 2, row + 2] == player;

                    if (rowWin || colWin || diagWinMain || diagWinAnti)
                        return true;
                }
            }

            return false;
        }


        public bool CheckDraw(CellState[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == CellState.Empty)
                        return false;
                }
            }
            return true;
        }
    }
}
