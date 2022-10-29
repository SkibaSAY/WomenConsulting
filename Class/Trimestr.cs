using Aspose.Words;
using Aspose.Words.Saving;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting.Class
{
    class Trimestr
    {
        #region Fields
        /// <summary>
        /// Адресс уже сохранённого ранее триместра
        /// </summary>
        public string Path { get; }


        /// <summary>
        /// Класс для работы с Word версией триместра
        /// </summary>
        private Document Document { get; }

        #endregion

        #region Constructors
        /// <summary>
        /// Используется, когда по пути лежит уже редактированный файл, а не шаблон
        /// </summary>
        /// <param name="path"></param>
        public Trimestr(string path)
        {
            if (File.Exists(path))
            {
                Document = new Document(path);
                Path = path;
            }
            else
            {
                throw new ArgumentException($"Файл {path} не существует");
            }
        }

        /// <summary>
        /// В случае, когда обьект создаётся с использованием шаблона
        /// </summary>
        /// <param name="samplePath">Шаблон документа</param>
        /// <param name="path">Путь к новому документу</param>
        public Trimestr(string samplePath,string path)
        {
            if (File.Exists(samplePath))
            {
                Document = new Document(samplePath);
                Path = path;
            }
            else
            {
                throw new ArgumentException($"Файл {samplePath} не существует");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// По задумке, выходное имя поля будет соответствовать названию поля(контрола в вёрстке)
        /// 
        /// Если будет передано имя поля, которое отсутствует в документе, будет ошибка
        /// </summary>
        /// <param name="fieldName">Поле в документе, по которому нужно занести значение</param>
        /// <param name="result">Значение, которое будет занесено в документ</param>
        public void UpdateField(string fieldName,string result)
        {
            var field = Document.Range.FormFields.Where(x => x.Name.Equals(fieldName)).FirstOrDefault();
            //возможно, стоит добавить обработку исключения, но пока не торопимся, тк это ошибка программиста
            field.Result = result;
        }

        /// <summary>
        /// Сохранение результата
        /// </summary>
        public void SaveTrimestr()
        {
            var sf = SaveOptions.CreateSaveOptions(SaveFormat.Docx);
            sf.ExportGeneratorName = false;
            Document.Save(Path, sf);
        }
        #endregion
    }
}
