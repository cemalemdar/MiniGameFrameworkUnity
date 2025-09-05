using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Games;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class AsyncSceneManager : SerializedMonoBehaviour, ISceneManager
    {
        [SerializeField] private Dictionary<GameType, string> sceneNames;

        private static AsyncSceneManager _instance;
        public static AsyncSceneManager Instance => _instance ??= new AsyncSceneManager();


        private void OnEnable()
        {
            EventManager.Register<LoadSceneEvent>(OnLoadScene);
        }

        private void OnDisable()
        {
            EventManager.Unregister<LoadSceneEvent>(OnLoadScene);
        }

        private void OnLoadScene(LoadSceneEvent ev)
        {
            // Get scene name from dictionary
            string scene;
            if (sceneNames.TryGetValue(ev.gameType, out scene))
            {
                LoadScene(scene);
            }

            else throw new Exception($"No scene found in sceneNames dictionary {sceneNames} ");
            
        }


        private IEnumerator LoadAsyncSceneAdditive(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadAsyncSceneAdditive(sceneName));
        }
    }
}