using UnityEngine;

namespace GFrame.UI
{
    public abstract class BaseUIPanel : MonoBehaviour, IUIPanel
    {
        public string PanelId => "BaseUIPanel";
        public bool IsVisible => gameObject.activeInHierarchy;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}

