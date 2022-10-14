namespace Apex.Consistency
{
    /// <summary>
    /// Provides a Silverlight/WPF independent way to get system parameters
    /// not in both platforms.
    /// </summary>
    public static class SystemParameters
    {
        /// <summary>
        /// Gets the minimum horizontal drag distance.
        /// </summary>
        public static double MinimumHorizontalDragDistance => System.Windows.SystemParameters.MinimumHorizontalDragDistance;

        /// <summary>
        /// Gets the minimum vertical drag distance.
        /// </summary>
        public static double MinimumVerticalDragDistance => System.Windows.SystemParameters.MinimumVerticalDragDistance;
    }
}