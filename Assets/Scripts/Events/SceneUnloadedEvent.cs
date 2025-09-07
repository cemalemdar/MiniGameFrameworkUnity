
namespace GFrame.Events
{
    public class SceneUnloadedEvent : CustomEvent
    {
        public string sceneName;
        public static SceneUnloadedEvent Create(string sceneName)
        {
            SceneUnloadedEvent sceneUnloadedEvent = new SceneUnloadedEvent();
            sceneUnloadedEvent.sceneName = sceneName;
            return sceneUnloadedEvent;
        }
    }
}

