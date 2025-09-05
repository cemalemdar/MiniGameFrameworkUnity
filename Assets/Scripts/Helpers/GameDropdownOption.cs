using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    [System.Serializable]
    public class GameDropdownOption : TMPro.TMP_Dropdown.OptionData
    {
        [SerializeField] private GameType gameType;
    }
}

