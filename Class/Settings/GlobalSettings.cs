﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class _Settings
    {
        public List<string> Doctors { get; set; } = new List<string>();
        [JsonIgnore]
        private string _baseProtocolsPath = "";
        public string BaseProtocolsPath
        {
            //когда потребуется, нужно получить непустой путь у пользователя
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
                        throw new UndefinedPathException("Для работы некоторых функций приложения требуется указать папку, куда по умолчанию будут сохранятся протоколы.");
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

        private PercentilTable _percentilTbl = new PercentilTable();
        public PercentilTable PercentilTbl
        {
            get { return _percentilTbl; }
            set
            {
                _percentilTbl = value;
            }
        }

        public MillimetrWeekTable MillimetrTbl { get; set; } = new MillimetrWeekTable();
        public _Settings() { 
        }

        public double constA = 0.27777;
        public double ConstA
        {
            get { return constA; }
            set
            {
                constA = value;
            }
        }

        public double constB = 0.001492;
        public double ConstB
        {
            get { return constB; }
            set
            {
                constB = value;
            }
        }
    }
    public static class GlobalSettings
    {
        [JsonIgnore]
        public static readonly string Path = "settings.json";
        [JsonIgnore]
        private static _Settings settings = new _Settings();

        public static string BaseProtocolsPath
        {
            get
            {
                return settings.BaseProtocolsPath;
            }
            set
            {
                settings.BaseProtocolsPath = value;
            }
        }

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

        public static PercentilTable PercentilTbl
        {
            get { return settings.PercentilTbl; }
            set { settings.PercentilTbl = value; }
        }

        public static MillimetrWeekTable MillimetrTbl
        {
            get { return settings.MillimetrTbl; }
            set { settings.MillimetrTbl = value; }
        }
        public static double ConstA
        {
            get { return settings.ConstA; }
            set { settings.ConstA = value; }
        }
        public static double ConstB
        {
            get { return settings.ConstB; }
            set { settings.ConstB = value; }
        }

        #region methods
        public static void Load()
        {
            try
            {
                if (File.Exists(Path))
                {
                    var content = File.ReadAllText(Path);
                    settings = null;
                    settings = JsonConvert.DeserializeObject<_Settings>(content, new JsonSerializerSettings
                    {
                        ObjectCreationHandling = ObjectCreationHandling.Replace
                    });
                }
            }
            catch (UndefinedPathException ex)
            {
                UserDialog.Message(ex.Message + $"\n\r Загрузка настроек пропущена, поскольку в загружаемом файле настроек({Path}) содержится некорректный путь к базовой директории.");
            }
        }
        public static void Save()
        {
            try
            {
                var content = JsonConvert.SerializeObject(settings);
                File.WriteAllText(Path, content);
            }
            catch (Exception ex)
            {
                UserDialog.Message("Сохранение настроек пропущено, поскольку не выбран базовый путь.");
            }
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
        #endregion
    }
}
