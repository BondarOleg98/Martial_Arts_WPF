using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public CoachDialogWindow(DataRowView dataRow)
        {
            InitializeComponent();
            string name = dataRow.Row["Name"].ToString();
            string surname = dataRow.Row["Surname"].ToString();
            string age = dataRow.Row["Age"].ToString();
            string belt = dataRow.Row["Belt"].ToString();
            textName.Text = name;
            textSurname.Text = surname;
            textAge.Text = age;
            textBelt.Text = belt;
        }
        public CoachDialogWindow()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(textAge.Text).GetType();
               
                string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string sql = "Insert into Coach (Name,Surname,Age,Belt) " +
                   "values('" + textName.Text + "','" +
                    textSurname.Text + "','" + textAge.Text + "','" + textBelt.Text + "')";
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    adapter.InsertCommand = new SqlCommand(sql, con);
                    adapter.InsertCommand.ExecuteNonQuery();
                }

                CoachWindow coachWindow = new CoachWindow();
                this.Close();
                
                coachWindow.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Error in a field age");
            }
            
        }
        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(textAge.Text).GetType();
   
                string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string sql = "Update Coach Set " +
               "Name='" + textName.Text + "', Surname='" + textSurname.Text + "', Age='" + textAge.Text + "', Belt='" + textBelt.Text + "'";


                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlConnection con = new SqlConnection(connetionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    adapter.UpdateCommand = new SqlCommand(sql, con);
                    adapter.UpdateCommand.ExecuteNonQuery();
                }
                CoachWindow coachWindow = new CoachWindow();
                this.Close();
                coachWindow.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in a field age");
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
