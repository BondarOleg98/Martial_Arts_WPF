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
        private string sql_edit { get; set; }

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
            textBelt.Text = student.Belt;
            string sql = "SELECT Id FROM Students WHERE Name='" + student.Name + "' AND Surname='" + textSurname.Text + "' " +
                "AND Age='" + textAge.Text + "'";
            sql_edit = sql;
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

                student.Age = Convert.ToInt32(textAge.Text);
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


                string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
               
                string sql = "Insert into Students (Name,Surname,Age,Belt) " +
                    "values('" + textName.Text + "','" +
                     textSurname.Text + "','" + textAge.Text + "','" + textBelt.Text + "')";
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
            //try
            //{
                Student student = new Student();

                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
                int id = 0;
                string sql = "";
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                   
                    SqlCommand command = new SqlCommand(sql_edit, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    reader.Close();

                    sql =String.Format("UPDATE Students SET Age = ('" + textAge.Text + "'), Name = ('" + textName.Text + "')," +
                        "Surname=('" + textSurname.Text + "'), Belt=('" + textBelt.Text + "') WHERE Id={0}",id);
                    command = new SqlCommand(sql, conn);
                    adapter.UpdateCommand = new SqlCommand(sql, conn);
                    adapter.UpdateCommand.ExecuteNonQuery();

                    command.Dispose();

                }
                ArtStudent artStudent = new ArtStudent();
                student.Name = textName.Text;
                student.Surname = textSurname.Text;
                student.Belt = textBelt.Text;

                student.Age = Convert.ToInt32(textAge.Text);
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
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Choose right categories");
            //}
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            StudentWindow studentWindow = new StudentWindow();          
            studentWindow.Show();
            this.Close();
        }
    }
}
