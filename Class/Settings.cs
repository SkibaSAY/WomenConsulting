using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting.Class
{
    public class Settings
    {
        [JsonIgnore]
        public static readonly string Path = "settings.json";
        public List<string> Doctors { get; set; } = new List<string>();

        [JsonIgnore]
        private static Settings settings = new Settings();

        public string _lastOpenDirectory = "";
        public static string LastOpenDirectory
        {
            get
            {
                return settings._lastOpenDirectory;
            }
            set
            {
                settings._lastOpenDirectory = value;
            }
        }

        public static void Load()
        {
            if (File.Exists(Path))
            {
                var content = File.ReadAllText(Path);
                settings = JsonConvert.DeserializeObject<Settings>(content);
            }
        }
        public static void Save()
        {
            var content = JsonConvert.SerializeObject(settings);
            File.WriteAllText(Path, content);
        }


        public static void AddDoctor(string NewDoctor)
        {
            settings.Doctors.Add(NewDoctor);
        }
        
        //убрать по имени
        public static void RemoveDoctor(string RemovedDoctor)
        {
            settings.Doctors.Remove(RemovedDoctor);
        }

        public static List<string> GetDoctors()
        {
            return settings.Doctors;
        }
    }
}
