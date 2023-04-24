using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eee
{
    internal class in_file
    {
        public static void Serialize<T>(ObservableCollection<T> note, string name)
        {

            string json = JsonConvert.SerializeObject(note);
            File.WriteAllText($"{name}.json", $"\r\n{json}");
        }

        public static ObservableCollection<T> Mydeserializer<T>(string name)
        {

            string json = File.ReadAllText($"{name}.json");
            ObservableCollection<T> note = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
            return note;
        }
    }
}