namespace GFrame.Events
{
    public class LoadSceneEvent : CustomEvent
    {
        public string sceneName;
        public static LoadSceneEvent Create(string sceneName)
        {
            LoadSceneEvent loadSceneEvent = new LoadSceneEvent();
            loadSceneEvent.sceneName = sceneName;
            return loadSceneEvent;
        }
    }
}

