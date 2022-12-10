using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class ProtocolCommonSettings: INotifyPropertyChanged
    {
        public string surnameName { get; set; } = "";
        public string address { get; set; } = "";
        public string age { get; set; } = "";
        public string dateOfLastMen { get; set; }
        private string _fetusCount;
        public string fetusCount
        {
            get
            {
                return _fetusCount;
            }
            set
            {
                _fetusCount = value;
                OnPropertyChanged("fetusCount");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ProtocolCommonSettings() { }
        public ProtocolCommonSettings(string surname,string address,string age, string dateOfLastMen,string fetusCount)
        {
            surnameName = surname;
            this.address = address;
            this.age = age;
            this.dateOfLastMen = dateOfLastMen;
            this.fetusCount = fetusCount;
        }

        public Dictionary<string,string> GetFields()
        {
            var result = new Dictionary<string, string>();
            foreach(var prop in typeof(ProtocolCommonSettings).GetProperties())
            {
                result.Add(prop.Name, prop.GetValue(this).ToString());
            }
            return result;
        }
        //другие поля пока не нужны
    }
}
