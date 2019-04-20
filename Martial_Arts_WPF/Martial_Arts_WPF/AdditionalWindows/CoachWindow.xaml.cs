﻿using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Martial_Arts.Data.Sportsman;
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

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string sql = "SELECT Name,Surname,Age,Belt FROM Coach";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {               
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
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
                DataRowView dataRow = listCoach.SelectedItem as DataRowView;
                string name = dataRow.Row["Name"].ToString();
                string surname = dataRow.Row["Surname"].ToString();
                string age = dataRow.Row["Age"].ToString();
                string belt = dataRow.Row["Belt"].ToString();

                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string sql = "DELETE FROM Coach WHERE Name='" + name + "' AND Surname='"+surname+"' " +
                    "AND Age='"+age+"' AND Belt='"+belt+"'";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    listCoach.ItemsSource = null;

                    DataTable data = new DataTable("Coach");
                    sql = "SELECT Name, Surname, Age, Belt FROM Coach";
                    command = new SqlCommand(sql, conn);
                 
                    sqlDataAdapter = new SqlDataAdapter(command);
                    
                    sqlDataAdapter.Fill(data);
                    listCoach.ItemsSource = data.DefaultView;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Don't have coaches");
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = listCoach.SelectedItem as DataRowView;
            if (dataRow == null)
            {
                MessageBox.Show("Choose a coach");
            }
            else
            {            
                CoachDialogWindow coachDialogWindow = new CoachDialogWindow(dataRow);
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
          
        }

        
    }
}
