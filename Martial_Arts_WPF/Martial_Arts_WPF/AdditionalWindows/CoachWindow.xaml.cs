using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Martial_Arts.Data.Sportsman;
using System;
using System.Data.Linq;
using Martial_Arts.Data;
using System.Linq;
using System.Collections.Generic;

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
                listCoach.ItemsSource = data.DefaultView;
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
                string id = "";
                try
                {
                    DataRowView dataRow = listCoach.SelectedItem as DataRowView;
                    id = dataRow.Row["Pk_Coach_Id"].ToString();
                }
                catch (Exception)
                {

                    MessageBox.Show("Error: don't has a coach");
                }           
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                string sql = "DELETE FROM Coach WHERE Pk_Coach_id='" + id + "'";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    listCoach.ItemsSource = null;

                    DataTable data = new DataTable("Coach");
                    sql = "SELECT * FROM Coach";
                    command = new SqlCommand(sql, conn);
                 
                    sqlDataAdapter = new SqlDataAdapter(command);
                    
                    sqlDataAdapter.Fill(data);
                    listCoach.ItemsSource = data.DefaultView;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error: delete a student at first");
            }

        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = listCoach.SelectedItem as DataRowView;
            string id = dataRow.Row["Pk_Coach_id"].ToString();
            if (dataRow == null)
            {
                MessageBox.Show("Choose a coach");
            }
            else
            {            
                CoachDialogWindow coachDialogWindow = new CoachDialogWindow(dataRow,id);
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
            DataRowView dataRow = listCoach.SelectedItem as DataRowView;
            int id = Convert.ToInt32(dataRow.Row["Pk_Coach_Id"]);
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connetionString);
            
            Table<Person> students = db.GetTable<Person>();
            List<Person> coaches = new List<Person>();
            foreach (var item in students)
            {
                if (item.Fk_Coach_id == id)
                {
                    coaches.Add(item);
                }
            }
            listStudents.ItemsSource = coaches;

        }

        
    }
}
