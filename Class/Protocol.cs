using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WomenConsulting.Class;

namespace WomenConsulting
{
    public class Protocol: INotifyPropertyChanged
    {
        public ObservableCollection<Fetus> fetuses { get; set; }
        public GeneralSettings generalSettings { get; set; }

        public void UpdateBindings()
        {
            OnPropertyChanged("fetuses");
            OnPropertyChanged("generalSettings");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Protocol(string currentDirectory)
        {
            InitFetuses(currentDirectory);
            InitGeneralSettings();
        }

        private void InitGeneralSettings()
        {
            generalSettings = new GeneralSettings();
            var allDocs = fetuses.SelectMany(
                x => x.GetType().GetProperties()
                    .Where(y => y.PropertyType.Equals(typeof(Trimestr)))
                    .Select(z => ((Trimestr)z.GetValue(x)).Document)
                    ).ToList();

            foreach (var property in typeof(GeneralSettings).GetProperties())
            {
                var propertyName = property.Name;
                var value = FindPropertyValue(allDocs, propertyName);
                property.SetValue(generalSettings, value);
            }
        }
        private string FindPropertyValue(List<Document>docs,string fieldName)
        {
            string result;
            var correspondFields = new List<string>();
            foreach (var doc in docs) correspondFields.AddRange(doc.Range.FormFields.Where(x=>x.Name.Equals(fieldName)).Select(x=>x.Result).ToList());
            
            result = correspondFields.OrderByDescending(s => s.Length).FirstOrDefault();
            if (result == null) return "";
            return result;
        }

        private void InitFetuses(string currentDirectory)
        {
            fetuses = new ObservableCollection<Fetus>();

            var maxCount = 1;
            //существование и создание по шаблону учти в конструкторах триместров(см. далее)
            var firstTrimPath = GetPathToCurDocumentOrSampleDocument(currentDirectory, Sample.FirstTrimestrName);
            var firstTrimList = SplitDocumentBySections(firstTrimPath);
            if (maxCount < firstTrimList.Count) maxCount = firstTrimList.Count;

             var secondTrimPath = GetPathToCurDocumentOrSampleDocument(currentDirectory, Sample.SecondTrimestrName);
            var secondTrimList = SplitDocumentBySections(secondTrimPath);
            if (maxCount < secondTrimList.Count) maxCount = secondTrimList.Count;

            var thirdTrimPath = GetPathToCurDocumentOrSampleDocument(currentDirectory, Sample.ThirdTrimestrName);
            var thirdTrimList = SplitDocumentBySections(thirdTrimPath);
            if (maxCount < thirdTrimList.Count) maxCount = thirdTrimList.Count;

            var malyeSrokiPath = GetPathToCurDocumentOrSampleDocument(currentDirectory, Sample.MalyeSrokiName);
            var malyeSrokiList = SplitDocumentBySections(malyeSrokiPath);
            if (maxCount < malyeSrokiList.Count) maxCount = malyeSrokiList.Count;

            //считаем, что число плодов одинаково во всех триместрах, но стоит подумать, что если не так - будет ведь ошибка.
            //есть вариант дополнять пустые места шаблонами.
            //тут и заполняет пустые места
            FillTheCaps(firstTrimList, Sample.FirstTrimestrFullName, maxCount);
            FillTheCaps(secondTrimList, Sample.SecondTrimestrFullName, maxCount);
            FillTheCaps(thirdTrimList, Sample.ThirdTrimestrFullName, maxCount);
            FillTheCaps(malyeSrokiList, Sample.MalyeSrokiFullName, maxCount);

            for (var i = 0; i < firstTrimList.Count; i++)
            {
                var newName = $"Плод_{i+1}";
                var newFetus = new Fetus(newName, firstTrimList[i], secondTrimList[i], thirdTrimList[i], malyeSrokiList[i]);
                fetuses.Add(newFetus);
            }
        }
        /// <summary>
        /// Заполняет документы шаблонами до указанного количества
        /// </summary>
        /// <param name="documents"></param>
        /// <param name="sampleFullName"></param>
        /// <param name="neededCount"></param>
        private void FillTheCaps(List<Document> documents,string sampleFullName,int neededCount)
        {
            while (documents.Count < neededCount) documents.Add(new Document(sampleFullName));
        }
        private List<Document> SplitDocumentBySections(string docPath)
        {
            var childList = new List<Document>();

            var parentDoc = new Document(docPath);

            foreach (var sec in parentDoc.Sections)
            {
                var newDoc = new Document();
                newDoc.Sections.Clear();

                //взяли секцию вместе с вложенными элементами
                var newSection = (Section)newDoc.ImportNode(sec, true);

                newDoc.Sections.Add(newSection);
                childList.Add(newDoc);
            }

            return childList;
        }

        /// <summary>
        /// Возращает путь в документу из указанной директории, если он есть, или возвращает путь к шаблону, соответсвующему этому документу.
        /// </summary>
        /// <param name="currentDirectory"></param>
        /// <param name="fileName">имя файла, совпадает с шаблонным именем</param>
        /// <returns></returns>
        /// Важно, чтобы шаблон с таким именем был.
        private string GetPathToCurDocumentOrSampleDocument(string currentDirectory,string fileName)
        {
            //попытались в директории найти файл, его имя совпадает с шаблоном.
            var currentPath = Path.Combine(currentDirectory, fileName);

            //если файла нет, то в качестве документа будет использоваться шаблон, путь к его директории в Sample
            if (!File.Exists(currentPath))
                currentPath = Path.Combine(Sample.Directory, fileName);

            return currentPath;
        }
        public void Save(string CurrentDirectory)
        {
            var firstTrimList = fetuses.Select(x => x.trimestr1.Document).ToArray();
            SaveSeveralDocsAsOne(firstTrimList,Path.Combine(CurrentDirectory,Sample.FirstTrimestrName));

            var secondTrimList = fetuses.Select(x => x.trimestr2.Document).ToArray();
            SaveSeveralDocsAsOne(secondTrimList, Path.Combine(CurrentDirectory, Sample.SecondTrimestrName));

            var thirdTrimList = fetuses.Select(x => x.trimestr3.Document).ToArray();
            SaveSeveralDocsAsOne(thirdTrimList, Path.Combine(CurrentDirectory, Sample.ThirdTrimestrName));

            var malyeSrokiList = fetuses.Select(x => x.malyeSroki.Document).ToArray();
            SaveSeveralDocsAsOne(malyeSrokiList, Path.Combine(CurrentDirectory, Sample.MalyeSrokiName));
        }
        private void SaveSeveralDocsAsOne(IEnumerable<Document> docs,string outDocPath)
        {
            foreach (var doc in docs) FillGeneralSettings(doc);
            var mergedDoc = MergeTrimestrDocument(docs);
            mergedDoc.Save(outDocPath);
        }
        private void FillGeneralSettings(Document doc)
        {
            var generalFields = generalSettings.GetFields();
            foreach(var field in generalFields)
            {
                var findedField = doc.Range.FormFields.Where(x => x.Name.Equals(field.Key)).FirstOrDefault();
                if (findedField != null)
                {
                    findedField.Result = field.Value;
                }
            }
        }
        private Document MergeTrimestrDocument(IEnumerable<Document> docs)
        {
            var newDoc = new Document();
            newDoc.Sections.Clear();

            foreach (var doc in docs)
            {       
                //взяли секцию вместе с вложенными элементами
                var sec = (Section)newDoc.ImportNode(doc.FirstSection, true);

                newDoc.Sections.Add(sec);
            }
            return newDoc;
        }
        public void AddFetus(Fetus newFetus)
        {
            fetuses.Add(newFetus);
            generalSettings.fetusCount = FetusCount.GetStringFetusCount(fetuses.Count);
            UpdateBindings();
        }
        public void DeleteFetus(int fetusIndex)
        {
            if(fetuses.Count <= fetusIndex || fetusIndex < 0)
            {
                throw new IndexOutOfRangeException("Вы пытаетесь удалить плод по некорректному индексу");
            }

            string msgtext = $"Вы точно хотите удалить {fetuses[fetusIndex].Name}?";
            string txt = "Подтверждение";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = System.Windows.MessageBox.Show(msgtext, txt, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    fetuses.RemoveAt(fetusIndex);
                    generalSettings.fetusCount = FetusCount.GetStringFetusCount(fetuses.Count);
                    UpdateBindings();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }
    }
}
