using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting.Class
{
    /// <summary>
    /// плод
    /// </summary>
    public class Woman: INotifyPropertyChanged
    {
        public DirectoryInfo Directory;
        public Trimestr trimestr1 { get; set; }
        public Trimestr trimestr2 { get; set; }
        public Trimestr trimestr3 { get; set; }


        public Woman(string path)
        {
            Directory = new DirectoryInfo(path);
            trimestr1 = new Trimestr(Path.Combine(Directory.FullName, "1_trimestr.docx"), @"..\..\Шаблоны\1_trimestr.docx", new Trimestr1());
            trimestr2 = new Trimestr(Path.Combine(Directory.FullName, "2_trimestr.docx"), @"..\..\Шаблоны\2_trimestr.docx", new Trimestr2());
            trimestr3 = new Trimestr(Path.Combine(Directory.FullName, "3_trimestr.docx"), @"..\..\Шаблоны\3_trimestr.docx", new Trimestr3());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Для удобства обернем событие в метод с единственным параметром - имя изменяемого свойства
        public void RaisePropertyChanged(string propertyName)
        {
            // Если кто-то на него подписан, то вызывем его
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
