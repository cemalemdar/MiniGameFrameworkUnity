using GFrame.UI;

namespace GFrame.Managers
{
    public interface IUIManager
    {
        /// <summary>
        /// Shows a UI panel by name/id.
        /// </summary>
        void ShowPanel(string panelId);

        /// <summary>
        /// Hides a UI panel by name/id.
        /// </summary>
        void HidePanel(string panelId);

        /// <summary>
        /// Adds a UI panel with id/RectTransform.
        /// </summary>
        void AddPanel(string panelId, BaseUIPanel RectTransform);

        /// <summary>
        /// Toggles visibility of a UI panel.
        /// </summary>
        void TogglePanel(string panelId);

        /// <summary>
        /// Hides all currently active panels.
        /// </summary>
        void HideAll();

        /// <summary>
        /// Checks whether a panel is currently visible.
        /// </summary>
        bool IsVisible(string panelId);
    }
}

