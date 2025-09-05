using System.Collections.Generic;
using UnityEngine;
using Games;
using Sirenix.OdinInspector;
using Events;
using System;

namespace Managers
{
    public class GameFrameworkManager : SerializedMonoBehaviour
    {
        private readonly Dictionary<GameType, IMiniGame> registeredGames = new Dictionary<GameType, IMiniGame>();
        private IMiniGame activeGame;
        private GameContext sharedContext;

        // Static singleton instance
        private static GameFrameworkManager Instance;

        private void Awake()
        {
            // 
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            RegisterGame(GameType.TicTacToe, new TicTacToeGame());
            // TODO Put More Games Here
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            EventManager.Register<LoadGameEvent>(OnLoadGame);
        }

        private void OnDisable()
        {
            EventManager.Unregister<LoadGameEvent>(OnLoadGame);
        }

        private void OnLoadGame(LoadGameEvent ev)
        {
            EventManager.Send(LoadSceneEvent.Create(ev.gameType));
            StartGame(ev.gameType);

        }

        /// <summary>
        /// Register a new mini-game with the framework.
        /// </summary>
        public void RegisterGame(GameType gameType, IMiniGame game)
        {
            if (!registeredGames.ContainsKey(gameType))
            {
                registeredGames.Add(gameType, game);
                Debug.Log($"Registered game: {gameType}");
            }
        }

        /// <summary>
        /// Start a registered mini-game by ID.
        /// </summary>
        public void StartGame(GameType gameType)
        {
            if (!registeredGames.TryGetValue(gameType, out IMiniGame game)) throw new Exception($"Game type is not registered {gameType}");

            if (activeGame != null)
            {
                StopGame();
            }

            activeGame = game;
            activeGame.Initialize(sharedContext);
            activeGame.StartGame();
            Debug.Log($"Started game: {gameType}");
        }

        /// <summary>
        /// Stop the currently running game.
        /// </summary>
        public void StopGame()
        {
            if (activeGame == null) return;

            activeGame.EndGame();
            activeGame.CleanUp();
            Debug.Log($"Stopped game.");
            activeGame = null;
        }
    }
}
