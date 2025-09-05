using UnityEngine;
using TMPro;
using Games;
using Events;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Dropdown selectGameDropdown;

        private GameType selectedGameType;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        public void PlayGame()
        {
            EventManager.Send(LoadGameEvent.Create(selectedGameType));
        }

        public void SetTitle(string title)
        {
            titleText.text = title;
        }


    }
}

