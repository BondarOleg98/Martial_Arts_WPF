using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data.Sportsman;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Relationship;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Linq;
using Martial_Arts.Data;
using System.Linq;
using System.Windows.Controls;
using System.Data;
using System;

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
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connetionString);
            Table<Person> students = db.GetTable<Person>();
            listStudent.ItemsSource = students;
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
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connetionString);
            Student student = new Student();
       
            int id  = (listStudent.SelectedItem as Student).Pk_Person_Id;
            student.Pk_Person_Id = id;
            var st = db.GetTable<Person>().SingleOrDefault(p=>p.Pk_Person_Id==id);
            Table<ArtStudent> artStudents = db.GetTable<ArtStudent>();
            
            foreach (var item in artStudents)
            {
                if (item.Id_Student == id)
                {
                    db.GetTable<ArtStudent>().DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }

            db.GetTable<Person>().DeleteOnSubmit(st as Person);
            db.SubmitChanges();
            Table<Person> students = db.GetTable<Person>();
            listStudent.ItemsSource = students;
            listMartialArts.ItemsSource = null;
            listMartialArts.Items.Refresh();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (listStudent.SelectedItem as Student).Pk_Person_Id;
                StudentDialogWindow studentDialogWindow = new StudentDialogWindow(listStudent.SelectedItem as Student);
                studentDialogWindow.bt_Add.IsEnabled = false;
                studentDialogWindow.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose a student");
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
            try
            {
                int id = (listStudent.SelectedItem as Student).Pk_Person_Id;
                string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DataContext db = new DataContext(connetionString);
                Table<ArtStudent> artStudents = db.GetTable<ArtStudent>();
                Table<MartialArt> martialArts = db.GetTable<MartialArt>();
                List<int> arts = new List<int>();
                List<MartialArt> ma = new List<MartialArt>();
                foreach (var item in artStudents)
                {
                    if (item.Id_Student == id)
                    {
                        arts.Add(item.Id_Art);
                    }
                }
                foreach (var item in martialArts)
                {
                    foreach (var _item in arts)
                    {
                        if (item.Pk_Art_Id == _item)
                        {
                            ma.Add(item);
                        }
                    }
                }

                listMartialArts.ItemsSource = ma;
            }
            catch (Exception)
            {
                MessageBox.Show("Choose a student");
            }
            

        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
