using System.Windows;

namespace Apex.Consistency
{
    /// <summary>
    /// Consistent GridLengthConverter for Apex.
    /// </summary>
    public class GridLengthConverter
    {
        /// <summary>
        /// Create a grid length from a string, consistently in WPF, WP7 and SL.
        /// </summary>
        /// <param name="gridLength">The grid length, e.g. 4*, Auto, 23 etc.</param>
        /// <returns>A gridlength.</returns>
        public GridLength ConvertFromString(string gridLength)
        {
            //  Create the standard windows grid length converter.
            var gridLengthConverter = new System.Windows.GridLengthConverter();

            //  Return the converted grid length.
            return (GridLength)gridLengthConverter.ConvertFromString(gridLength);
        }
    }
}