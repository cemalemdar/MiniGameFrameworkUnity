using System.Collections;
using System.Collections.Generic;
using GFrame.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GFrame.Managers
{
    public class AsyncSceneManager : MonoBehaviour, ISceneManager
    {
        // Tracks currently loaded scene names
        private HashSet<string> loadedScenes = new HashSet<string>();

        private void OnEnable()
        {
            EventManager.RegisterHandler<LoadSceneEvent>(OnLoadScene);
        }

        private void OnDisable()
        {
            EventManager.UnregisterHandler<LoadSceneEvent>(OnLoadScene);
        }

        private void OnLoadScene(LoadSceneEvent ev)
        {
            
            LoadScene(ev.sceneName);

        }

        private IEnumerator LoadAsyncSceneAdditive(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            loadedScenes.Add(sceneName);
            EventManager.SendEvent(SceneLoadedEvent.Create(sceneName));
            Debug.Log($"Loaded scene: {sceneName}");
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadAsyncSceneAdditive(sceneName));
        }

        private IEnumerator UnloadAsyncScene(string sceneName)
        {
            if (!loadedScenes.Contains(sceneName))
            {
                Debug.LogWarning($"Scene {sceneName} is not loaded, cannot unload.");
                yield break;
            }

            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);

            while (!asyncUnload.isDone)
            {
                yield return null;
            }

            loadedScenes.Remove(sceneName);
            EventManager.SendEvent(SceneUnloadedEvent.Create(sceneName));
            Debug.Log($"Unloaded scene: {sceneName}");
        }

        public void UnloadScene(string sceneName)
        {
            StartCoroutine(UnloadAsyncScene(sceneName));
        }
    }
}
