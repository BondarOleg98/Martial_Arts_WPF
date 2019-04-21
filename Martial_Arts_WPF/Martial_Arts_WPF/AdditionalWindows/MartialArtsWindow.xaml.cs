using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Sportsman;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Martial_Arts.Data.Relationship;

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
            listMartialArts.ItemsSource = MartialArt.martialArts;
            listMartialArts.Items.Refresh();
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
            var martialArt = (MartialArt)listMartialArts.SelectedItem;
          
            MartialArt.martialArts.Remove(martialArt);
            listMartialArts.Items.Refresh();

            Student.Students.Clear();
            listStudent.ItemsSource = Student.Students;
            listStudent.Items.Refresh();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int art_Id = listMartialArts.SelectedIndex;
            var martial_arts = (MartialArt)listMartialArts.SelectedItem;
            if (art_Id == -1)
            {
                MessageBox.Show("Choose an art");
            }
            else
            {

                MartialArtsDialogWindow martialArtsDialogWindow = new MartialArtsDialogWindow(art_Id, martial_arts);
                martialArtsDialogWindow.bt_Add.IsEnabled = false;
                martialArtsDialogWindow.Show();
                this.Close();

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
            //Student.Students.Clear();
            //listStudent.ItemsSource = Student.Students;
            //listStudent.Items.Refresh();

            //MartialArt MartialArts = (MartialArt)listMartialArts.SelectedItem;
            //if (MartialArts != null)
            //{
            //    foreach (Student item in MartialArts.Students)
            //    {
            //        if (item != null)
            //        {
            //            Student.Students.Add(item);
            //            listStudent.ItemsSource = Student.Students;
            //            listStudent.Items.Refresh();
            //        }
            //    }
            //}
            
            
           
        }
    }
}
