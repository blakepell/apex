// -----------------------------------------------------------------------
// <copyright file="EnumComboBoxViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Apex.MVVM;

namespace Gallery.Controls.EnumComboBox
{
    /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class EnumComboBoxViewModel : GalleryItemViewModel
  {
        public EnumComboBoxViewModel()
        {
            this.Title = "EnumComboBox";
        }

    private NotifyingProperty ExampleEnumerationProperty =
      new NotifyingProperty("ExampleEnumeration", typeof(ExampleEnumeration), ExampleEnumeration.Oracle);

    public ExampleEnumeration ExampleEnumeration
    {
      get => (ExampleEnumeration)this.GetValue(ExampleEnumerationProperty);
      set => this.SetValue(ExampleEnumerationProperty, value);
    }
  }
}
