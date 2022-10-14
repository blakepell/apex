using System.Collections.ObjectModel;

namespace Gallery.Behaviours.ListViewItemContextMenuBehaviour
{
    public class ListViewItemContextMenuBehaviourViewModel : GalleryItemViewModel
    {
        public ListViewItemContextMenuBehaviourViewModel()
        {
            this.Title = "ListViewItemContextMenuBehaviour";

            this.People.Add(new PersonViewModel() { FirstName = "Homer", LastName = "Simpson" });
            this.People.Add(new PersonViewModel() { FirstName = "Marge", LastName = "Simpson" });
            this.People.Add(new PersonViewModel() { FirstName = "Bart", LastName = "Simpson" });
            this.People.Add(new PersonViewModel() { FirstName = "Lisa", LastName = "Simpson" });
            this.People.Add(new PersonViewModel() { FirstName = "Maggie", LastName = "Simpson" });
        }

        
        /// <summary>
        /// The People observable collection.
        /// </summary>
        private ObservableCollection<PersonViewModel> PeopleProperty =
          new ObservableCollection<PersonViewModel>();

        /// <summary>
        /// Gets the People observable collection.
        /// </summary>
        /// <value>The People observable collection.</value>
        public ObservableCollection<PersonViewModel> People => PeopleProperty;
    }
}
