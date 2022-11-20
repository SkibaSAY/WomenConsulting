using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WomenConsulting.Class
{
    [Serializable]
    class Settings
    {
        public List<string> Doctors { get; set; }
        public string LastOpenDirectory { get; set; }
        public Settings()
        {

        }
        public void AddDoctor(string NewDoctor)
        {
            Doctors.Add(NewDoctor);
        }

        //убрать по индексу
        //public void RemoveDoctor(int Position)
        //{
        //    Doctors.RemoveAt(Position);
        //}
        
        //убрать по имени
        public void RemoveDoctor(string RemovedDoctor)
        {
            Doctors.Remove(RemovedDoctor);
        }

        public List<string> GetDoctors()
        {
            return Doctors;
        }

        public void UpdateLastOpened(string NewPath)
        {
            LastOpenDirectory = NewPath;
        }

        public string GetLastOpened()
        {
            return LastOpenDirectory;
        }
    }
}
