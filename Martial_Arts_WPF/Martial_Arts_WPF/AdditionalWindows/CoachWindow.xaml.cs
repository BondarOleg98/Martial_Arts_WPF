using System.Linq;
using System.Windows;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace Martial_Arts_WPF.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window
    {
        public CoachWindow()
        {

            InitializeComponent();
            //listCoach.ItemsSource = Coach.coaches;
            //listCoach.Items.Refresh();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string sqlExpression = "SELECT * FROM Coach";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object name = reader.GetValue(1);
                        object surname = reader.GetValue(2);
                        listCoach.Items.Add(surname.ToString());
                      
                    }
                }

                reader.Close();
            }
        }


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            
            CoachDialogWindow coachDialogWindow = new CoachDialogWindow();
            coachDialogWindow.bt_Edit.IsEnabled = false;
            this.Close();
            coachDialogWindow.Show();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var coach = (Coach)listCoach.SelectedItem;

                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string sql = "DELETE FROM Coach WHERE Name='" + coach.Name + "' AND Surname='" + coach.Surname + "' AND " +
                    "Age='" + coach.Age + "' AND Belt='" + coach.Belt + "'";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.ExecuteNonQuery();
                }

                //Coach.coaches.Remove(coach);
                //listCoach.Items.Refresh();
                //Coach.students.Clear();
                //listStudents.ItemsSource = Coach.students;
                //listStudents.Items.Refresh();
            }          
            catch (Exception)
            {

                MessageBox.Show("Delete a student at first");
            }

        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int coach_Id = listCoach.SelectedIndex;
            var coach = (Coach)listCoach.SelectedItem;
            if (coach_Id ==-1 )
            {
                MessageBox.Show("Choose a coach");
            }
            else
            {
                CoachDialogWindow coachDialogWindow = new CoachDialogWindow(coach_Id, coach);
                coachDialogWindow.bt_Add.IsEnabled = false;
                this.Close();
                coachDialogWindow.Show();
            }    
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
          
            MainWindow mainWindow = new MainWindow(1);
            this.Close();
            mainWindow.Show();
        }

        private void Button_Show_Click(object sender, RoutedEventArgs e)
        {
            //Coach.students.Clear();
            //listStudents.ItemsSource = Coach.students;
            //listStudents.Items.Refresh();
            //var Coaches = (Coach)listCoach.SelectedItem;
            //foreach (var item in Student._students)
            //{
            //    if(item._coachId == Coaches.Id)
            //    {
            //        Coach.students.Add(item);
            //        listStudents.ItemsSource = Coach.students;
            //        listStudents.Items.Refresh();
            //    }
                   
            //}
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string sqlExpression = "SELECT * FROM Students";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        object name = reader.GetValue(1);
                        object surname = reader.GetValue(2);

                        listStudents.Items.Add(surname);
                    }
                }

                reader.Close();
            }
        }
    }
}
