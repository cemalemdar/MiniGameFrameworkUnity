using UnityEngine;
using System.Collections.Generic;
using GFrame.UI;

namespace GFrame.Managers
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private Canvas mainCanvas;

        [SerializeField] private List<UIPanelEntry> panelEntries = new List<UIPanelEntry>();

        private Dictionary<string, BaseUIPanel> panels = new Dictionary<string, BaseUIPanel>();

        private void Awake()
        {
            panels.Clear();
            foreach (var entry in panelEntries)
            {
                if (entry.panel == null || string.IsNullOrEmpty(entry.panelId)) continue;

                SpawnPanel(entry);
            }
        }

        public void ShowPanel(string panelId)
        {
            if (panels.TryGetValue(panelId, out var panel))
                panel.Show();
        }

        public void HidePanel(string panelId)
        {
            if (panels.TryGetValue(panelId, out var panel))
                panel.Hide();
        }

        public void TogglePanel(string panelId)
        {
            if (panels.TryGetValue(panelId, out var panel))
                if (panel.IsVisible) panel.Hide();
                else panel.Show();
        }

        public void HideAll()
        {
            foreach (var panel in panels.Values)
                panel.Hide();
        }

        public bool IsVisible(string panelId)
        {
            return panels.TryGetValue(panelId, out var panel) && panel.IsVisible;
        }

        public void SpawnPanel(UIPanelEntry uIPanelEntry)
        {
            GameObject panelObject = Instantiate(uIPanelEntry.panel.gameObject, mainCanvas.transform);
            BaseUIPanel panel = panelObject.GetComponent<BaseUIPanel>();
            panelObject.SetActive(false);

            AddPanel(uIPanelEntry.panelId, panel);
            
        }

        public void AddPanel(string panelId, BaseUIPanel UIpanel)
        {
            if (!panels.ContainsKey(panelId))
                panels.Add(panelId, UIpanel);
        }

        public void RemovePanel(string panelId)
        {
            panels.Remove(panelId);
        }
    }

    [System.Serializable]
    public class UIPanelEntry
    {
        public string panelId;
        public BaseUIPanel panel;
    }
}
