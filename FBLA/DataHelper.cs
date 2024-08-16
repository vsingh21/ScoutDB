using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace FBLA
{
    public static class DataHelper
    {
        private const string DataFilePath = "partners.json"; // Adjust the path as needed

        public static void SaveData(ObservableCollection<Partner> partners)
        {
            // Serialize and save Partners to a JSON file
            string jsonData = JsonSerializer.Serialize(partners);
            File.WriteAllText(DataFilePath, jsonData);
        }

        public static ObservableCollection<Partner> LoadData()
        {
            // Load data from the JSON file if it exists, otherwise create a new collection
            if (File.Exists(DataFilePath))
            {
                string jsonData = File.ReadAllText(DataFilePath);
                return JsonSerializer.Deserialize<ObservableCollection<Partner>>(jsonData);
            }
            else
            {
                return new ObservableCollection<Partner>();
            }
        }
    }
}
