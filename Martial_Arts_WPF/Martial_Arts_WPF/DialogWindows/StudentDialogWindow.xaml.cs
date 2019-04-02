using System;
using System.Windows;
using Martial_Arts.Data.Relationship;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.AdditionalWindows;
using Martial_Arts.Data.Structure;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

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
            listMartialArts.ItemsSource = MartialArt.martialArts;
        }
        public StudentDialogWindow(int student_Id, Student student, Coach coach)
        {
           
            InitializeComponent();
            textName.Text = student.Name;
            textSurname.Text = student.Surname;
            textAge.Text = student.Age.ToString();
            textBelt.Text = student.Belt.ToString();
            comboBoxCoaches.ItemsSource = Coach.coaches;
            listMartialArts.ItemsSource = MartialArt.martialArts;
            Id_Student = student_Id;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{

                Student student = new Student();
                ArtStudent artStudent = new ArtStudent();
                student.Name = textName.Text;
                student.Surname = textSurname.Text;
                student.Belt = textBelt.Text;

                student.Age = Convert.ToInt16(textAge.Text);
                student.Coach = (Coach)comboBoxCoaches.SelectedItem;
                if ((MartialArt)listMartialArts.SelectedItem != null)
                {
                    artStudent.MartialArt = (MartialArt)listMartialArts.SelectedItem;
                    artStudent.Student = student;
                    ArtStudent.ArtStudents.Add(artStudent);
                }
                if (comboBoxCoaches.SelectedItem == null)
                {
                    MessageBox.Show("Choose a coach");
                }

                Student._students.Add(student);


                string connetionString = connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
               
                String sql = "Insert into Students (Name,Surname,Age,Belt) " +
                    "values(N'" + textName.Text + "',N'" +
                     textSurname.Text + "',N'" + textAge.Text + "',N'" + textBelt.Text + "')";
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);

                    adapter.InsertCommand = new SqlCommand(sql, con);
                    adapter.InsertCommand.ExecuteNonQuery();

                    //sql = "SELECT Id FROM Students WHERE Name=2";
                    //command = new SqlCommand(sql, con);
                    //SqlDataReader reader = command.ExecuteReader();
                    ////while (reader.Read())
                    ////{
                    ////int id = reader.GetInt32(0);
                    ////}

                    command.Dispose();
                    
                }
              

                StudentWindow studentWindow = new StudentWindow();
                this.Close();
                studentWindow.Show();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Choose all categories");
            //}
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = new Student();
                ArtStudent artStudent = new ArtStudent();
                student.Name = textName.Text;
                student.Surname = textSurname.Text;
                student.Belt = textBelt.Text;

                student.Age = Convert.ToInt16(textAge.Text);
                student.Coach = (Coach)comboBoxCoaches.SelectedItem;
                if ((MartialArt)listMartialArts.SelectedItem == null)
                {
                    throw new Exception();
                }
                else
                {
                    artStudent.MartialArt = (MartialArt)listMartialArts.SelectedItem;
                    artStudent.Student = student;
                    ArtStudent.ArtStudents.Add(artStudent);
                }

                if (comboBoxCoaches.SelectedItem == null)
                {
                    throw new Exception();
                }
                
                Student._students.RemoveAt(Id_Student);
                Student._students.Insert(Id_Student, student);
              
                StudentWindow studentWindow = new StudentWindow();            
                studentWindow.Show();
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Choose right categories");
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
