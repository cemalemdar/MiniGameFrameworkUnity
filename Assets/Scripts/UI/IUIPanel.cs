namespace GFrame.UI
{
    public interface IUIPanel
    {
        /// <summary>
        /// Unique identifier for this panel (e.g., "MainMenu", "GameOver").
        /// </summary>
        string PanelId { get; }

        /// <summary>
        /// Show the panel (make visible, animate in, etc).
        /// </summary>
        void Show();

        /// <summary>
        /// Hide the panel (make invisible, animate out, etc).
        /// </summary>
        void Hide();

        /// <summary>
        /// Whether the panel is currently visible.
        /// </summary>
        bool IsVisible { get; }
    }
}

