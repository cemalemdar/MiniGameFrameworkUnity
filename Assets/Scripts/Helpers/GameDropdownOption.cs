using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame.Games
{
    [System.Serializable]
    public class GameDropdownOption : TMPro.TMP_Dropdown.OptionData
    {
        [SerializeField] private string gameID;
    }
}

