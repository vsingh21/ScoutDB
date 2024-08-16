using System.Linq;
using System.Windows;

namespace FBLA
{
    public partial class EditPartnerWindow : Window
    {
        private Partner _selectedPartner;

        public EditPartnerWindow(Partner selectedPartner)
        {
            InitializeComponent();
            _selectedPartner = selectedPartner;
            FillFields(); // Fill the text fields with the data of the selected partner
        }

        // Fill the text fields with the data of the selected partner
        private void FillFields()
        {
            organizationTextBox.Text = _selectedPartner.Organization;
            typeTextBox.Text = _selectedPartner.Type;
            resourcesTextBox.Text = _selectedPartner.Resources;
            contactPersonTextBox.Text = _selectedPartner.ContactPerson;
            contactEmailTextBox.Text = _selectedPartner.ContactEmail;
            contactPhoneTextBox.Text = _selectedPartner.ContactPhone;
        }

        // Event handler for the Save button click
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Check if any required field is empty
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

            // Proceed with saving the data if validation passes
            _selectedPartner.Organization = organizationTextBox.Text;
            _selectedPartner.Type = typeTextBox.Text;
            _selectedPartner.Resources = resourcesTextBox.Text;
            _selectedPartner.ContactPerson = contactPersonTextBox.Text;
            _selectedPartner.ContactEmail = contactEmailTextBox.Text;
            _selectedPartner.ContactPhone = contactPhoneTextBox.Text;
            MessageBox.Show("Changes saved successfully.", "Edit Partner", MessageBoxButton.OK, MessageBoxImage.Information);
            DataHelper.SaveData(MainWindow.Partners); // Save data after editing
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

        // Event handler for the Cancel button click
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window without saving changes
        }
    }
}
