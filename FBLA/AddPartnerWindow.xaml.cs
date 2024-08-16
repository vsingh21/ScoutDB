using System;
using System.Linq;
using System.Windows;

namespace FBLA
{
    public partial class AddPartnerWindow : Window
    {
        public AddPartnerWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(organizationTextBox.Text) ||
                string.IsNullOrWhiteSpace(typeTextBox.Text) ||
                string.IsNullOrWhiteSpace(resourcesTextBox.Text) ||
                string.IsNullOrWhiteSpace(contactPersonTextBox.Text) ||
                string.IsNullOrWhiteSpace(contactEmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(contactPhoneTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit the method if any required field is empty
            }

            // Validation for email format
            if (!IsValidEmail(contactEmailTextBox.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validation for phone number format
            if (!IsValidPhoneNumber(contactPhoneTextBox.Text))
            {
                MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Proceed with adding the new partner if validation passes
            Partner newPartner = new Partner(
                organizationTextBox.Text,
                typeTextBox.Text,
                resourcesTextBox.Text,
                contactPersonTextBox.Text,
                contactEmailTextBox.Text,
                contactPhoneTextBox.Text
            );

            // Add newPartner to the main window's Partners collection or your data storage
            MainWindow.Partners.Add(newPartner);
            MessageBox.Show("Changes saved successfully.", "Edit Partner", MessageBoxButton.OK, MessageBoxImage.Information);
            DataHelper.SaveData(MainWindow.Partners); // Save data after editing
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Function to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // Function to validate phone number format
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Remove any non-digit characters from the phone number
            string cleanedPhoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Check if the cleaned phone number has at least 7 digits (adjust as needed)
            if (cleanedPhoneNumber.Length < 7)
                return false;

            // Additional validation for specific formats can be added here
            // For simplicity, let's assume any phone number with at least 7 digits is valid
            return true;
        }

    }
}
