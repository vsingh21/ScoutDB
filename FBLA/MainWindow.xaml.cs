using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FBLA
{
    public partial class MainWindow : Window
    {
        private const string DataFilePath = "partners.json";
        public static ObservableCollection<Partner> Partners { get; set; }
        private Timer backupTimer;
        private const int BackupIntervalMinutes = 10; 

        public MainWindow()
        {
            InitializeComponent();
            Partners = DataHelper.LoadData(); // Load partners data from file
            partnersDataGrid.ItemsSource = Partners; // Set data source for data grid

            InitializeBackupTimer();
        }

        private void InitializeBackupTimer()
        {
            backupTimer = new Timer();
            backupTimer.Interval = BackupIntervalMinutes * 60 * 1000; // Convert minutes to milliseconds
            backupTimer.Elapsed += OnBackupTimerElapsed;
            backupTimer.Start();
        }

        private void OnBackupTimerElapsed(object sender, ElapsedEventArgs e)
        {
            SaveBackupData();
        }

        private void SaveBackupData()
        {
            string backupFileName = $"partners_backup_{DateTime.Now:yyyyMMddHHmmss}.json"; // creates a name for the backup with the time included
            string backupFilePath = Path.Combine(Environment.CurrentDirectory, backupFileName); // creates a path to the proper directory, referencing the file name
            string jsonData = JsonSerializer.Serialize(Partners); // serializes the "partners" array into a json file
            File.WriteAllText(backupFilePath, jsonData); // writes all json to the backup file using WriteAllText function
        }

        // Reset button click event handler
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            partnersDataGrid.ItemsSource = Partners;
            partnersDataGrid.Items.Filter = null; // Clear any applied filter
            // Clear any applied filter
            partnersDataGrid.Items.Filter = null;

            // Clear sorting
            ICollectionView dataView = CollectionViewSource.GetDefaultView(partnersDataGrid.ItemsSource);
            dataView.SortDescriptions.Clear();

            // Reset column sorting indicators
            foreach (var column in partnersDataGrid.Columns)
            {
                column.SortDirection = null;
            }

            // Refresh the DataGrid
            partnersDataGrid.Items.Refresh();
        }

        // AddPartner button click event handler
        private void AddPartner_Click(object sender, RoutedEventArgs e)
        {
            AddPartnerWindow addPartnerWindow = new AddPartnerWindow();
            addPartnerWindow.Owner = this;
            addPartnerWindow.ShowDialog();
        }

        // Search button click event handler
        private void SearchPartners_Click(object sender, RoutedEventArgs e)
        {
            SearchPartnerWindow searchPartnerWindow = new SearchPartnerWindow(Partners);
            searchPartnerWindow.Owner = this;
            searchPartnerWindow.ShowDialog();
        }

        // DataGrid double click event handler
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (partnersDataGrid.SelectedItem != null)
            {
                // Edit the selected partner
                Partner selectedPartner = (Partner)partnersDataGrid.SelectedItem;
                EditPartnerWindow editPartnerWindow = new EditPartnerWindow(selectedPartner);
                editPartnerWindow.Owner = this;
                editPartnerWindow.ShowDialog();

                // Refresh the DataGrid after editing
                partnersDataGrid.Items.Refresh();
                SaveData(); // Save data after editing
            }
        }

        // DataGrid key down event handler
        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && partnersDataGrid.SelectedItem != null)
            {
                // Delete the selected partner
                Partner selectedPartner = (Partner)partnersDataGrid.SelectedItem;
                Partners.Remove(selectedPartner);

                // Save data after deleting
                DataHelper.SaveData(Partners);
            }
        }

        // Save data to file
        public void SaveData()
        {
            string jsonData = JsonSerializer.Serialize(Partners);
            File.WriteAllText(DataFilePath, jsonData);
        }

        // Load data from file
        private void LoadData()
        {
            if (File.Exists(DataFilePath))
            {
                string jsonData = File.ReadAllText(DataFilePath);
                Partners = JsonSerializer.Deserialize<ObservableCollection<Partner>>(jsonData);
            }
            else
            {
                Partners = new ObservableCollection<Partner>();
            }
        }

        // Window closing event handler
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            DataHelper.SaveData(Partners);
        }

        // Help button click event handler
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Owner = this;
            helpWindow.ShowDialog();
        }

        // SearchTextBox text changed event handler
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();
            var filteredPartners = Partners.Where(p =>
                p.Organization.ToLower().Contains(searchText) ||
                p.Type.ToLower().Contains(searchText) ||
                p.Resources.ToLower().Contains(searchText) ||
                p.ContactPerson.ToLower().Contains(searchText) ||
                p.ContactEmail.ToLower().Contains(searchText) ||
                p.ContactPhone.ToLower().Contains(searchText)
            ).ToList();

            partnersDataGrid.ItemsSource = filteredPartners;
        }
    }
}
