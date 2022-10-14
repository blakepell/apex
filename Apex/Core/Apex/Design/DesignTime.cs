using System.ComponentModel;
using System.Windows;

namespace Apex.Design
{
    /// <summary>
    /// Class for design time functionality.
    /// </summary>
    public static class DesignTime
    {
        /// <summary>
        /// Gets a value indicating whether the control is in design mode (running in Blend
        /// or Visual Studio).
        /// </summary>
        public static bool IsDesignTime => DesignerProperties.GetIsInDesignMode(new DependencyObject());
    }
}