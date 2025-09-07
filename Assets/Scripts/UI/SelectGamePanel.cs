using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GFrame.Events;
using GFrame.Games;

namespace GFrame.UI
{
    public class SelectGamePanel : BaseUIPanel
    {
        [SerializeField] private TMP_Dropdown gameDropdown;
        [SerializeField] private Button playButton;

        private List<string> gameIDs = new List<string>();

        private void Start()
        {
            if (playButton != null)
                playButton.onClick.AddListener(OnPlayClicked);

            PopulateDropdown();
        }

        private void PopulateDropdown()
        {
            gameDropdown.ClearOptions();

            // Pull registered games from framework
            var registered = GFrameManagers.GamesDatabase.Games.Keys;

            gameIDs.Clear();
            foreach (string key in registered)
            {
                gameIDs.Add(key);
            }

            gameDropdown.AddOptions(gameIDs);
            
        }

        private void OnPlayClicked()
        {
            if (gameDropdown.value < 0 || gameDropdown.value >= gameIDs.Count) return;
            string selectedGameKey = gameIDs[gameDropdown.value];
            GameConfig selectedGameConfig = GFrameManagers.GamesDatabase.Games[selectedGameKey];
            Debug.Log($"Loading Game {selectedGameKey}");

            GFrameManagers.EventManager.Send(LoadGameEvent.Create(selectedGameConfig));
        }
    }
}
