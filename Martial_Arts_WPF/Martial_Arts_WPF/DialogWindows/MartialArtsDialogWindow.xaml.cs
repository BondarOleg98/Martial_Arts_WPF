using System.Windows;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.AdditionalWindows;
using System;
using Martial_Arts.Data.Relationship;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Data.Linq;
using Martial_Arts.Data;
using System.Linq;

namespace Martial_Arts_WPF.DialogWindows
{
    /// <summary>
    /// Interaction logic for StructureDialogWindow.xaml
    /// </summary>
    public partial class MartialArtsDialogWindow : Window
    {
        private int Id_Art { get; set; }
        public MartialArtsDialogWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connectionString);
            Table<Person> students = db.GetTable<Person>();
            listStudents.ItemsSource = students;

        }
        public MartialArtsDialogWindow(MartialArt martialArt)
        {

            InitializeComponent();
            textName.Text = martialArt.Name;
            Id_Art = martialArt.Pk_Art_Id;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connectionString);
            Table<Person> students = db.GetTable<Person>();
            listStudents.ItemsSource = students;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DataContext db = new DataContext(connectionString);
                int id = (listStudents.SelectedItem as Student).Pk_Person_Id;
                MartialArt art = new MartialArt
                {
                    Name = textName.Text
                };
                db.GetTable<MartialArt>().InsertOnSubmit(art);
                db.SubmitChanges();

                var ast = db.GetTable<MartialArt>().OrderByDescending(a => a.Pk_Art_Id).FirstOrDefault();

                ArtStudent artStudent = new ArtStudent
                {
                    Id_Student = id,
                    Id_Art = ast.Pk_Art_Id
                };
                db.GetTable<ArtStudent>().InsertOnSubmit(artStudent);
                db.SubmitChanges();

                MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
          
                this.Close();
                martialArtsWindow.Show();

            }
            catch (Exception)
            {

                MessageBox.Show("Choose right categories");
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DataContext db = new DataContext(connectionString);
                var ma = db.GetTable<MartialArt>().SingleOrDefault(m => m.Pk_Art_Id == Id_Art);
                ma.Name = textName.Text;
                db.SubmitChanges();

                MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
                martialArtsWindow.Show();
                this.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Choose right categories");
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MartialArtsWindow martialArt = new MartialArtsWindow();
            martialArt.Show();
            this.Close();
        }
    }
}
