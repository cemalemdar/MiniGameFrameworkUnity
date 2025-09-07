using GFrame.Events;
using TicTacToe.Game;

namespace TicTacToe.Events
{
    public class CellTappedEvent : CustomEvent
    {
        public Cell tappedCell;
        public static CellTappedEvent Create(Cell tappedCell)
        {
            CellTappedEvent cellTappedEvent = new CellTappedEvent();
            cellTappedEvent.tappedCell = tappedCell;
            return cellTappedEvent;
        }
    }
}

