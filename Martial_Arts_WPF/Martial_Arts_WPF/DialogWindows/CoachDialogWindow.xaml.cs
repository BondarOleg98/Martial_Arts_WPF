﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.AdditionalWindows;
namespace Martial_Arts_WPF.DialogWindows
{
    /// <summary>
    /// Interaction logic for CoachDialogWindow.xaml
    /// </summary>
    public partial class CoachDialogWindow : Window
    {
        private int Id_Coach { get; set; }

        public CoachDialogWindow(int coach_Id, Coach coach)
        {
            InitializeComponent();
            textName.Text = coach.Name;
            textSurname.Text = coach.Surname;
            textAge.Text = coach.Age.ToString();
            textBelt.Text = coach.Belt.ToString();

            Id_Coach = coach_Id;
        }
        public CoachDialogWindow()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Coach coach = new Coach(textName.Text, textSurname.Text, textBelt.Text, Convert.ToInt16(textAge.Text));
              
                if ((Convert.ToInt16(textAge.Text)).GetType() == typeof(int))
                {
                    throw new Exception("Error");
                }
                Coach.coaches.Add(coach);
                CoachWindow coachWindow = new CoachWindow();

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Coach>));

                using (FileStream fs = new FileStream("coach.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, Coach.coaches);
                }

                StudentWindow studentWindow = new StudentWindow();

                this.Close();
                coachWindow.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Coach coach = new Coach(textName.Text, textSurname.Text, textBelt.Text, Convert.ToInt16(textAge.Text));

                if ((Convert.ToInt16(textAge.Text)).GetType() == typeof(int))
                {
                    throw new Exception("Error 404: ");
                }
                Coach.coaches.RemoveAt(Id_Coach);
                Coach.coaches.Insert(Id_Coach, coach);
                CoachWindow coachWindow = new CoachWindow();
                this.Close();
                coachWindow.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid age");
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            CoachWindow coachWindow = new CoachWindow();
            coachWindow.Show();
            this.Close();
        }
    }
}
