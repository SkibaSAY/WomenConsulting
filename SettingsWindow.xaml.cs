﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WomenConsulting.Class;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            List<String> Doctors = Settings.GetDoctors();
            foreach (var item in Doctors)
            {
                DoctorsList.Items.Add(item);
            }

        }
        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow addDoctorWindow = new AddDoctorWindow();
            addDoctorWindow.ShowDialog();
            if ((bool)addDoctorWindow.DialogResult)
            {
                Settings.AddDoctor(addDoctorWindow.DoctorName);
                DoctorsList.Items.Add(addDoctorWindow.DoctorName);
            }
        }
        private void RemoveDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorsList.SelectedItem != null)
            {
                string msgtext = $"Вы точно хотите удалить выбранного врача?";
                string txt = "";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxResult result = System.Windows.MessageBox.Show(msgtext, txt, button);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Settings.RemoveDoctor(DoctorsList.SelectedItem.ToString());
                        DoctorsList.Items.Remove(DoctorsList.SelectedItem);
                        break;
                    case MessageBoxResult.No:

                        break;
                }
            }
        }
    }
}