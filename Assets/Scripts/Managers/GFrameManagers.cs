using UnityEngine;
using GFrame.Managers;
using GFrame.Games;
using GFrame.Data;
using GFrame.Events;

namespace GFrame
{
    [DefaultExecutionOrder(-1)]
    public class GFrameManagers : MonoBehaviour
    {
        public static GFrameManagers Instance;

        [Header("Core Managers")]
        [SerializeField] private IEventManager eventManager;
        [SerializeField] private ISaveManager saveManager;
        [SerializeField] private IUIManager uiManager;
        [SerializeField] private ISceneManager sceneManager;
        [SerializeField] private RegisteredGamesDatabase gamesDatabase;

        private static IMiniGame activeGame;

        public static IEventManager EventManager => Instance.eventManager;
        public static ISaveManager SaveManager => Instance.saveManager;
        public static IUIManager UIManager => Instance.uiManager;
        public static ISceneManager SceneManager => Instance.sceneManager;
        public static RegisteredGamesDatabase GamesDatabase => Instance.gamesDatabase;

        //public static GameContext SharedContext { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            GetManagers();

            DontDestroyOnLoad(gameObject);

            // Build shared context
            //SharedContext = new GameContext(eventManager, saveManager, uiManager, sceneManager);
        }

        private void GetManagers()
        {
            eventManager = GetComponent<IEventManager>();
            saveManager = GetComponent<ISaveManager>();
            uiManager = GetComponent<IUIManager>();
            sceneManager = GetComponent<ISceneManager>();
        }

        private void OnEnable()
        {
            EventManager.Register<LoadGameEvent>(OnLoadGame);
            EventManager.Register<SceneLoadedEvent>(OnSceneLoaded);
        }

        private void OnDisable()
        {
            EventManager.Unregister<LoadGameEvent>(OnLoadGame);
            EventManager.Register<SceneLoadedEvent>(OnSceneLoaded);
        }

        

        private void OnLoadGame(LoadGameEvent ev)
        {
            EventManager.Send(LoadSceneEvent.Create(ev.gameConfig.GameSceneName));
            Debug.Log($"Loading Scene: {ev.gameConfig.GameSceneName}");
            StartGame(ev.gameConfig.GameID);

        }

        private void OnSceneLoaded(SceneLoadedEvent ev)
        {
            Debug.Log($"Loaded Scene: {ev.sceneName}");

            
        }

        /// <summary>
        /// Start a registered mini-game by ID.
        /// </summary>
        public static void StartGame(string gameID)
        {
            if (!Instance.gamesDatabase.Games.TryGetValue(gameID, out GameConfig gameConfig))
                throw new System.Exception($"Game ID not registered: {gameID}");

            if (activeGame != null)
            {
                StopGame();
            }

            // Hide current UI
            Debug.Log(" Hide UI");
            UIManager.HideAll();

            activeGame = gameConfig.Minigame;
            activeGame.Initialize(gameConfig);
            activeGame.StartGame();
            Debug.Log($"Started game: {gameID}");
        }

        /// <summary>
        /// Stop the currently running game.
        /// </summary>
        public static void StopGame()
        {
            if (activeGame == null) return;

            activeGame.EndGame();
            activeGame.CleanUp();
            Debug.Log("Stopped active game.");
            activeGame = null;
        }
    }
}

