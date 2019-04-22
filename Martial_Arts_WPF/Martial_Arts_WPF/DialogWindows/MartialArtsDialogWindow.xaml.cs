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
        public MartialArtsDialogWindow(int art_Id, MartialArt martialArt)
        {

            InitializeComponent();
            textName.Text = martialArt.Name;
            //listStudents.ItemsSource = Student._students;

            //Id_Art = art_Id;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connectionString);
            Table<Person> students = db.GetTable<Person>();
            listStudents.ItemsSource = students;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DataContext db = new DataContext(connectionString);
                int id = (listStudents.SelectedItem as Student).Pk_Person_Id;
                MartialArt art = new MartialArt
                {
                    Name = textName.Text
                //Surname = textSurname.Text,
                //Age = Convert.ToInt32(textAge.Text),
                //Belt = textBelt.Text,
                //Fk_Coach_id = id
                };
                db.GetTable<MartialArt>().InsertOnSubmit(art);
                db.SubmitChanges();

            //    List<MartialArt> mart = new List<MartialArt>();
            //    foreach (var item in mart)
            //{
            //    if (item.Name == textName.Text)
            //    {
            //        mart.Add(item);
            //    }
            //}

                var ast = db.GetTable<MartialArt>().OrderByDescending(a => a.Pk_Art_Id).FirstOrDefault();

            ArtStudent artStudent = new ArtStudent
                {
                    Id_Student = id,
                    Id_Art = ast.Pk_Art_Id
                };
                db.GetTable<ArtStudent>().InsertOnSubmit(artStudent);
                db.SubmitChanges();
               
            //DataRowView dataRow = listCoach.SelectedItem as DataRowView;
            //int id = Convert.ToInt32(dataRow.Row["Pk_Coach_Id"]);
            //string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //DataContext db = new DataContext(connetionString);

                
            //List<Person> coaches = new List<Person>();
            //foreach (var item in students)
            //{
            //    if (item.Fk_Coach_id == id)
            //    {
            //        coaches.Add(item);
            //    }
            //}
           
            //MartialArt martialArt = new MartialArt();
            //ArtStudent artStudent = new ArtStudent();
            //martialArt.Name = textName.Text;
            //if ((Student)listStudents.SelectedItem != null)
            //{
            //    artStudent.Student = (Student)listStudents.SelectedItem;
            //    artStudent.MartialArt = martialArt;
            //    ArtStudent.ArtStudents.Add(artStudent);
            //}

            //MartialArt.martialArts.Add(martialArt);

            MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
          
                this.Close();
                martialArtsWindow.Show();

            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Choose right categories");
            //}
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //MartialArt martialArt = new MartialArt();
                //ArtStudent artStudent = new ArtStudent();
                //martialArt.Name = textName.Text;
                //if ((Student)listStudents.SelectedItem != null)
                //{
                //    artStudent.Student = (Student)listStudents.SelectedItem;
                //    artStudent.MartialArt = martialArt;
                //    ArtStudent.ArtStudents.Add(artStudent);
                //}
                //MartialArt.martialArts.RemoveAt(Id_Art);
                //MartialArt.martialArts.Insert(Id_Art, martialArt);
               
                //MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
               
                //martialArtsWindow.Show();
                //this.Close();
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
