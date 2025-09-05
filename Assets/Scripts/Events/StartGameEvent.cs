namespace Events
{
    public class StartGameEvent : CustomEvent
    {
        public static StartGameEvent Create()
        {
            StartGameEvent startGameEvent = new StartGameEvent();
            return startGameEvent;
        }
    }
}
