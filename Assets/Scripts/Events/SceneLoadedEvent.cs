namespace GFrame.Events
{
    public class SceneLoadedEvent : CustomEvent
    {
        public string sceneName;
        public static SceneLoadedEvent Create(string sceneName)
        {
            SceneLoadedEvent sceneLoadedEvent = new SceneLoadedEvent();
            sceneLoadedEvent.sceneName = sceneName;
            return sceneLoadedEvent;
        }
    }
}

