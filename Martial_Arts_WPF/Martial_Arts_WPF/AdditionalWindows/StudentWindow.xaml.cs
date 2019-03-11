﻿using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data.Sportsman;
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
               
                StudentDialogWindow studentDialogWindow = new StudentDialogWindow(student_Id, student);
               
                studentDialogWindow.bt_Add.IsEnabled = false;
                
                studentDialogWindow.Show();
                this.Close();

            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow mainWindow = new MainWindow();
          
            mainWindow.Show();
            this.Close();
        }
    }
}
