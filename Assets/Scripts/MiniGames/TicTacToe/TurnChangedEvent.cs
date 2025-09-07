using GFrame.Events;

namespace TicTacToe.Events
{
    public class TurnChangedEvent : CustomEvent
    {
        public static TurnChangedEvent Create()
        {
            TurnChangedEvent turnChangedEvent = new TurnChangedEvent();
            return turnChangedEvent;
        }
    }
}

