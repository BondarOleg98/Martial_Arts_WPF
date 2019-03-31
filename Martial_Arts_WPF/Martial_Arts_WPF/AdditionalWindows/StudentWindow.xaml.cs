using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data.Sportsman;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Relationship;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace Martial_Arts_WPF.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for StudenrWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
            listStudent.ItemsSource = Student._students;
            listStudent.Items.Refresh();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
           
            StudentDialogWindow studentDialogWindow = new StudentDialogWindow();
           
            studentDialogWindow.bt_Edit.IsEnabled = false;
            studentDialogWindow.Show();
            this.Close();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)listStudent.SelectedItem;

            Student._students.Remove(student);
            listStudent.Items.Refresh();

            MartialArt._martialArts.Clear();
            listMartialArts.ItemsSource = MartialArt._martialArts;
            listMartialArts.Items.Refresh();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int student_Id = listStudent.SelectedIndex;
            var student = (Student)listStudent.SelectedItem;
            if (student_Id == -1)
            {
                MessageBox.Show("Choose a student");
            }
            else
            {      
                StudentDialogWindow studentDialogWindow = new StudentDialogWindow(student_Id, student, student.Coach);            
                studentDialogWindow.bt_Add.IsEnabled = false;                
                studentDialogWindow.Show();
                this.Close();
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow mainWindow = new MainWindow(1);
          
            mainWindow.Show();
            this.Close();
        }

        private void Button_Show_Click(object sender, RoutedEventArgs e)
        {
            MartialArt._martialArts.Clear();
            listMartialArts.ItemsSource = MartialArt._martialArts;
            listMartialArts.Items.Refresh();
            Student Students = (Student)listStudent.SelectedItem;
            if (Students != null)
            {
                foreach (MartialArt item in Students.MartialArts)
                {
                    if (item != null)
                    {
                        MartialArt._martialArts.Add(item);
                        listMartialArts.ItemsSource = MartialArt._martialArts;
                        listMartialArts.Items.Refresh();
                    }

                }
            }
           

        }
    }
}
