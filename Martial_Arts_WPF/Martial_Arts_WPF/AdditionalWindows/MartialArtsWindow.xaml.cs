using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Sportsman;
using System.Collections.Generic;
using Martial_Arts.Data.Relationship;
using System;
using System.Configuration;
using System.Data.Linq;
using Martial_Arts.Data;
using System.Linq;

namespace Martial_Arts_WPF.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for StructureWindow.xaml
    /// </summary>
    public partial class MartialArtsWindow : Window
    {
        public MartialArtsWindow()
        {
            InitializeComponent();
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connetionString);
            Table<MartialArt> martialArts = db.GetTable<MartialArt>();
            listMartialArts.ItemsSource = martialArts;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            MartialArtsDialogWindow martialArtsDialogWindow = new MartialArtsDialogWindow();

            martialArtsDialogWindow.bt_Edit.IsEnabled = false;
            martialArtsDialogWindow.Show();
            this.Close();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            DataContext db = new DataContext(connetionString);
            MartialArt martialArt = new MartialArt();

            int id = (listMartialArts.SelectedItem as MartialArt).Pk_Art_Id;
            martialArt.Pk_Art_Id = id;
            var ma = db.GetTable<MartialArt>().SingleOrDefault(p => p.Pk_Art_Id == id);
            Table<ArtStudent> artStudents = db.GetTable<ArtStudent>();
            
            foreach (var item in artStudents)
            {
                if (item.Id_Art == id)
                {
                    db.GetTable<ArtStudent>().DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
            }

            db.GetTable<MartialArt>().DeleteOnSubmit(ma as MartialArt);
            db.SubmitChanges();
            Table<MartialArt> martialArts = db.GetTable<MartialArt>();
            listMartialArts.ItemsSource = martialArts;
            listStudent.ItemsSource = null;
            listStudent.Items.Refresh();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MartialArtsDialogWindow martialArtsDialogWindow = new MartialArtsDialogWindow(listMartialArts.SelectedItem as MartialArt);
                martialArtsDialogWindow.bt_Add.IsEnabled = false;
                martialArtsDialogWindow.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose an art");
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
                int id = (listMartialArts.SelectedItem as MartialArt).Pk_Art_Id;
                string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                DataContext db = new DataContext(connetionString);
                Table<ArtStudent> artStudents = db.GetTable<ArtStudent>();
                Table<Person> _students = db.GetTable<Person>();
                List<int> st = new List<int>();
                List<Person> students = new List<Person>();
                foreach (var item in artStudents)
                {
                    if (item.Id_Art == id)
                    {
                        st.Add(item.Id_Student);
                    }
                }
                foreach (var item in _students)
                {
                    foreach (var _item in st)
                    {
                        if (item.Pk_Person_Id == _item)
                        {
                            students.Add(item);
                        }
                    }
                }

                listStudent.ItemsSource = students;
            }
            catch (Exception)
            {
                MessageBox.Show("Choose a student");
            }

}
    }
}
