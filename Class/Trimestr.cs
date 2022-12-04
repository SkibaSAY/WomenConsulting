using Aspose.Words;
using Aspose.Words.Saving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WomenConsulting.Class
{
    public class Trimestr
    {
        #region Fields

        public Page TrimestrPage { get; set; }

        /// <summary>
        /// Класс для работы с Word версией триместра
        /// </summary>
        private Document document;
        public Document Document
        {
            get
            {
                UpdateDocument();
                return document;
            }
        }
        #endregion


        #region Constructors

        /// <summary>
        /// В случае, когда обьект создаётся с использованием шаблона
        /// </summary>
        /// <param name="samplePath">Шаблон документа</param>
        /// <param name="path">Путь к новому документу</param>
        public Trimestr(Document doc,Page page)
        {
            document = doc;
            TrimestrPage = page;

            UpdatePage();
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
            var field = document.Range.FormFields.Where(x => x.Name.Equals(fieldName)).FirstOrDefault();
            //возможно, стоит добавить обработку исключения, но пока не торопимся, тк это ошибка программиста
            field.Result = result;
        }

        public void UpdatePage()
        {
            var fields = document.Range.FormFields;
            foreach (var field in fields)
            {
                var pageControl = TrimestrPage.FindName(field.Name);
                if(pageControl == null) continue;

                if (pageControl is ComboBox)
                {
                    var comboBox = (pageControl as ComboBox);

                    comboBox.ItemsSource = null;
                    comboBox.Items.Clear();
                    foreach (var item in field.DropDownItems)
                    {
                        var comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Content = item;
                        comboBox.Items.Add(comboBoxItem);
                    }

                    comboBox.SelectedIndex = field.DropDownSelectedIndex;
                }
                else if (pageControl is TextBox)
                {
                    (pageControl as TextBox).Text = field.Result;
                }
                else if (pageControl is DatePicker)
                {
                    (pageControl as DatePicker).Text = field.Result;
                }
            }
            //заполнение списка врачей с учётом настроек
            var doctorList = TrimestrPage.FindName("doctorList") as ComboBox;
            var selectedDoctor = doctorList.SelectedItem;

            doctorList.ItemsSource = null;
            doctorList.Items.Clear();

            var doctorsInSettings = Settings.GetDoctors();
            doctorList.ItemsSource = doctorsInSettings;
            if (selectedDoctor != null)
            {
                var doctorName = (selectedDoctor as ComboBoxItem).Content.ToString();
                var selectedIndex = doctorsInSettings.FindIndex(x=>x.Equals(doctorName));
                if(selectedIndex == -1)
                {
                    doctorsInSettings.Add(doctorName);
                    selectedIndex = doctorList.Items.Count - 1;
                }
                doctorList.SelectedIndex = selectedIndex;
            }       

        }

        /// <summary>
        /// Обновление документа
        /// </summary>
        public void UpdateDocument()
        {
            //нашли все поля, которые нужно заполнить с формы
            var documentFields = document.Range.FormFields;

            //заполняем документ значениями полей с формы 
            foreach (var docField in documentFields)
            {
                var pageControl = TrimestrPage.FindName(docField.Name);
                
                //если на форме нет контрола с названием, как в документе - пропускаем
                if(pageControl == null) continue;

                if (pageControl is ComboBox) docField.Result = (pageControl as ComboBox).Text;
                else if (pageControl is TextBox) docField.Result = (pageControl as TextBox).Text;
                else if (pageControl is DatePicker) docField.Result = (pageControl as DatePicker).Text;
            }
        }
        #endregion

    }
}
