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
using System.Data.Linq;
using Martial_Arts.Data;
using System.Linq;
using System.Data;

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
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sql = "SELECT * FROM Coach";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable data = new DataTable("Coach");
                sqlDataAdapter.Fill(data);

                foreach (DataRow coach in data.Rows)
                {
                    comboBoxCoaches.Items.Add(coach["Name"].ToString());
                }
            }
            DataContext db = new DataContext(connectionString);
            Table<MartialArt> martialArts = db.GetTable<MartialArt>();
            listMartialArts.ItemsSource = martialArts;
           
        }
        public StudentDialogWindow(Student student)
        {        
            InitializeComponent();
            textName.Text = student.Name;
            textSurname.Text = student.Surname;
            textAge.Text = student.Age.ToString();
            textBelt.Text = student.Belt;
            Id_Student = student.Pk_Person_Id;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sql = "SELECT * FROM Coach";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable data = new DataTable("Coach");
                sqlDataAdapter.Fill(data);
                foreach (DataRow coach in data.Rows)
                {
                    comboBoxCoaches.Items.Add(coach["Name"].ToString());
                }
            }
            DataContext db = new DataContext(connectionString);
            Table<MartialArt> martialArts = db.GetTable<MartialArt>();
            listMartialArts.ItemsSource = martialArts;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = 0;
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DataContext db = new DataContext(connectionString);

                int id_a = (listMartialArts.SelectedItem as MartialArt).Pk_Art_Id;
                string coach = comboBoxCoaches.SelectedValue.ToString();
                string sql = "SELECT Pk_Coach_id FROM Coach WHERE Name='" + coach + "'";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                Student student = new Student
                {
                    Name = textName.Text,
                    Surname = textSurname.Text,
                    Age = Convert.ToInt32(textAge.Text),
                    Belt = textBelt.Text,
                    Fk_Coach_id = id
                };
                db.GetTable<Person>().InsertOnSubmit(student);
                db.SubmitChanges();

                var ast = db.GetTable<Person>().OrderByDescending(a => a.Pk_Person_Id).FirstOrDefault();

                ArtStudent artStudent = new ArtStudent
                {
                    Id_Student = ast.Pk_Person_Id,
                    Id_Art = id_a
                };
                db.GetTable<ArtStudent>().InsertOnSubmit(artStudent);
                db.SubmitChanges();
                StudentWindow studentWindow = new StudentWindow();
                this.Close();
                studentWindow.Show();
           
            }
            catch (Exception)
            {
                MessageBox.Show("Choose all categories");
            }
}

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DataContext db = new DataContext(connectionString);
                int id = 0;
                string coach = comboBoxCoaches.SelectedValue.ToString();
                string sql = "SELECT Pk_Coach_id FROM Coach WHERE Name='" + coach + "'";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                var st = db.GetTable<Person>().SingleOrDefault(p => p.Pk_Person_Id == Id_Student);
                st.Name = textName.Text;
                st.Surname = textSurname.Text;
                st.Age = Convert.ToInt32(textAge.Text);
                st.Belt = textBelt.Text;
                st.Fk_Coach_id = id;
                db.SubmitChanges();

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
