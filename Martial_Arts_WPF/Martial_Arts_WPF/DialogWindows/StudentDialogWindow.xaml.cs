﻿using System;
using System.Windows;
using System.Windows.Controls;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.AdditionalWindows;
namespace Martial_Arts_WPF.DialogWindows
{
    /// <summary>
    /// Interaction logic for StudentDialogWindow.xaml
    /// </summary>
    public partial class StudentDialogWindow : Window
    {
        public StudentDialogWindow()
        {
            InitializeComponent();

            foreach (var item in Coach.coaches)
            {
                RadioButton radiobutton = new RadioButton { Content = item.Name };
                stackpanel.Children.Add(radiobutton);
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student(textName.Text, textSurname.Text, textBelt.Text, Convert.ToInt16(textAge.Text));

                if ((Convert.ToInt16(textAge.Text)).GetType() == typeof(int))
                {
                    throw new Exception("Error 404: ");
                }
                Student._students.Add(student);
                StudentWindow studentWindow = new StudentWindow();
                this.Close();
                studentWindow.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
