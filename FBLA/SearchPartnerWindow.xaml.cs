using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FBLA
{
    public partial class SearchPartnerWindow : Window
    {
        private ObservableCollection<Partner> _partners;

        // Constructor to initialize the window with partner data
        public SearchPartnerWindow(ObservableCollection<Partner> partners)
        {
            InitializeComponent();
            _partners = partners; // Initialize the collection of partners
        }

        // Event handler for the Search button click
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = searchTextBox.Text.ToLower(); // Convert search term to lowercase for case-insensitive search
            var searchResults = _partners.Where(p =>
                p.Organization.ToLower().Contains(searchTerm) || // Search in organization
                p.Type.ToLower().Contains(searchTerm) ||        // Search in type
                p.Resources.ToLower().Contains(searchTerm) ||   // Search in resources
                p.ContactPerson.ToLower().Contains(searchTerm) || // Search in contact person
                p.ContactEmail.ToLower().Contains(searchTerm) || // Search in contact email
                p.ContactPhone.ToLower().Contains(searchTerm)    // Search in contact phone
            ).ToList();

            // Update the main window's DataGrid with the search results
            ((MainWindow)this.Owner).partnersDataGrid.ItemsSource = searchResults;

            MessageBox.Show($"Found {searchResults.Count} result(s).", "Search Partners", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); // Close the search window
        }

        // Event handler for the Cancel button click
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the search window without performing any action
        }
    }
}
