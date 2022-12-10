using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting.Class
{
    class BaseSettings
    {
        public List<string> Doctors { get; set; } = new List<string>();
        [JsonIgnore]
        private string _baseProtocolsPath = "";
        public string BaseProtocolsPath
        {
            get 
            {
                if (!Directory.Exists(_baseProtocolsPath))
                {
                    //если пользователь не выбрал директорию, нужно кинуть ошибку и обработать на уровнях ниже
                    if(!UserDialog.SelectDirectoryPath
                        (
                        out string selectedPath,
                        description:"Выберете базовую директорию, в которой будут храниться все протоколы по умолчанию."
                        )
                    )
                    {
                        throw new GlobalSettingsExceptions();
                    }
                    _baseProtocolsPath = selectedPath;
                }
                return _baseProtocolsPath;
            }
            set
            {
                if (Directory.Exists(value)) _baseProtocolsPath = value;               
            }
        }

        [JsonIgnore]
        public string _lastOpenDirectory = "";
        public string LastOpenDirectory
        {
            get
            {
                return _lastOpenDirectory;
            }
            set
            {
                if(Directory.Exists(value))_lastOpenDirectory = value;
            }
        }
    }
    public static class GlobalSettings
    {
        [JsonIgnore]
        public static readonly string Path = "settings.json";
        [JsonIgnore]
        private static BaseSettings settings = new BaseSettings();

        public static string LastOpenDirectory
        {
            get
            {
                return settings.LastOpenDirectory;
            }
            set
            {
                settings.LastOpenDirectory = value;
            }
        }

        public static void Load()
        {
            if (File.Exists(Path))
            {
                var content = File.ReadAllText(Path);
                settings = JsonConvert.DeserializeObject<BaseSettings>(content);
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
