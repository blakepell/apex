using System.Windows;
using Apex.Helpers.Popups;

namespace Apex.Shells
{
    /// <summary>
    /// An IShell interface represents a shell for an MVVM application.
    /// This could be a top level element in a web page (silverlight)
    /// a window (wpf) or a page in WP7.
    /// </summary>
    public interface IShell
    {
        /// <summary>
        /// Minimizes the shell, if supported.
        /// </summary>
        void DoMinimize();

        /// <summary>
        /// Maximizes the shell, if supported.
        /// </summary>
        void DoMaximize();

        /// <summary>
        /// Restores the shell, if supported.
        /// </summary>
        void DoRestore();

        /// <summary>
        /// Closes the shell, if supported.
        /// </summary>
        void DoClose();

        /// <summary>
        /// Gets the drag and drop host.
        /// </summary>
        DragAndDrop.DragAndDropHost DragAndDropHost { get; }

        /// <summary>
        /// Fullscreens the shell, if supported.
        /// </summary>
        void DoFullscreen();

        //  WPF Only: Silverlight cannot push a dispatcher frame and
        //  call the function below synchronously without blocking the UI.

        /// <summary>
        /// Pushes a popup onto the popup stack and displays it.
        /// Once the popup is closed, this function returns with
        /// the value of IPopup.GetPopupResult();
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <returns>The popup result.</returns>
        object ShowPopup(UIElement popup);
         
        /// <summary>
        /// Closes the popup.
        /// </summary>
        /// <param name="popup">The popup.</param>
        /// <param name="result">The popup result, which will be provided to the caller of ShowPopup.</param>
        void ClosePopup(UIElement popup, object result);

        /// <summary>
        /// Gets or sets the popup animation helper.
        /// </summary>
        /// <value>
        /// The popup animation helper.
        /// </value>
        PopupAnimationHelper PopupAnimationHelper { get; set; }
    }
}