using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WomenConsulting.Class;

namespace WomenConsulting
{
    public class Protocol
    {
        public List<Fetus> fetuses { get; set; }
        public GeneralSettings generalSettings { get; set; }

        public Protocol(string currentDirectory)
        {
            InitFetuses(currentDirectory);
            generalSettings = new GeneralSettings();
        }
        private void InitFetuses(string currentDirectory)
        {
            fetuses = new List<Fetus>();

            //существование и создание по шаблону учти в конструкторах триместров(см. далее)
            var firstTrimPath = GetPathToCurDocumentOrSampleDocument(currentDirectory, Sample.FirstTrimestrName);
            var firstTrimList = SplitDocumentBySections(firstTrimPath);

            var secondTrimPath = GetPathToCurDocumentOrSampleDocument(currentDirectory, Sample.SecondTrimestrName);
            var secondTrimList = SplitDocumentBySections(secondTrimPath);

            var thirdTrimPath = GetPathToCurDocumentOrSampleDocument(currentDirectory, Sample.ThirdTrimestrName);
            var thirdTrimList = SplitDocumentBySections(thirdTrimPath);

            //считаем, что число плодов одинаково во всех триместрах, но стоит подумать, что если не так - будет ведь ошибка.
            //есть вариант дополнять пустые места шаблонами.

            for(var i = 0; i < firstTrimList.Count; i++)
            {
                var newName = $"Плод_{i+1}";
                var newFetus = new Fetus(newName, firstTrimList[i], secondTrimList[i], thirdTrimList[i]);
                fetuses.Add(newFetus);
            }
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
            //временно
            //переписать после обсуждения логики сохранения

            var fetus = fetuses.First();
            fetus.trimestr1.SaveTrimestr(CurrentDirectory);
            fetus.trimestr2.SaveTrimestr(CurrentDirectory);
            fetus.trimestr3.SaveTrimestr(CurrentDirectory);
        }

    }
}
