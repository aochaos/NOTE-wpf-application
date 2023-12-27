using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace kursach
{
    public class DataAccess
    {
        public static void SaveUserData(ObservableCollection<Doc> list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText("docs.json", json);
        }

        public static ObservableCollection<Doc> LoadUserData()
        {
            if (File.Exists("docs.json"))
            {
                string json = File.ReadAllText("docs.json");
                return JsonSerializer.Deserialize<ObservableCollection<Doc>>(json);
            }
            return new ObservableCollection<Doc>();
        }
    }
}
