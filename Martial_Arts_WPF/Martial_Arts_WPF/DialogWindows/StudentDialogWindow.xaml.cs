using System;
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
        private int Id_Student { get; set; }

        public StudentDialogWindow()
        {
            InitializeComponent();
            comboBoxCoaches.ItemsSource = Coach.coaches;
        }
        public StudentDialogWindow(int student_Id, Student student)
        {
           
            InitializeComponent();
            textName.Text = student.Name;
            textSurname.Text = student.Surname;
            textAge.Text = student.Age.ToString();
            textBelt.Text = student.Belt.ToString();
            comboBoxCoaches.ItemsSource = Coach.coaches;
            Id_Student = student_Id;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Student student = new Student();
                student.Name = textName.Text;
                student.Surname = textSurname.Text;
                student.Belt = textBelt.Text;

                student.Age = Convert.ToInt16(textAge.Text);
                student.Coach = (Coach)comboBoxCoaches.SelectedItem;

                if(comboBoxCoaches.SelectedItem == null)
                {
                    MessageBox.Show("Choose a coach");
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

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student();
                student.Name = textName.Text;
                student.Surname = textSurname.Text;
                student.Belt = textBelt.Text;

                student.Age = Convert.ToInt16(textAge.Text);
                student.Coach = (Coach)comboBoxCoaches.SelectedItem;

                if (comboBoxCoaches.SelectedItem == null)
                {
                    MessageBox.Show("Choose a coach");
                }
                Student._students.RemoveAt(Id_Student);
                Student._students.Insert(Id_Student, student);
              
                StudentWindow studentWindow = new StudentWindow();            
                studentWindow.Show();
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid age");
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            StudentWindow studentWindow = new StudentWindow();          
            studentWindow.Show();
            this.Close();
        }
    }
}
