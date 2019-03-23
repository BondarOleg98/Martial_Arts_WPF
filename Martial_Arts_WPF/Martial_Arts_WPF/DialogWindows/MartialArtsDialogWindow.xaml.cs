using System.Windows;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.AdditionalWindows;
using System;
using Martial_Arts.Data.Relationship;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

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
            listStudents.ItemsSource = Student._students;
        }
        public MartialArtsDialogWindow(int art_Id, MartialArt martialArt)
        {

            InitializeComponent();
            textName.Text = martialArt.Name;
            listStudents.ItemsSource = Student._students;
           
            Id_Art = art_Id;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                MartialArt martialArt = new MartialArt();
                ArtStudent artStudent = new ArtStudent();
                martialArt.Name = textName.Text;
                if ((Student)listStudents.SelectedItem != null)
                {
                    artStudent.Student = (Student)listStudents.SelectedItem;
                    artStudent.MartialArt = martialArt;
                    ArtStudent.ArtStudents.Add(artStudent);
                }
               
                

                MartialArt.martialArts.Add(martialArt);
                MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
                this.Close();
                martialArtsWindow.Show();

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<MartialArt>));

                using (FileStream fs = new FileStream("martial_art.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, MartialArt._martialArts);
                }

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

                MartialArt martialArt = new MartialArt();
                ArtStudent artStudent = new ArtStudent();
                martialArt.Name = textName.Text;
                if ((Student)listStudents.SelectedItem != null)
                {
                    artStudent.Student = (Student)listStudents.SelectedItem;
                    artStudent.MartialArt = martialArt;
                    ArtStudent.ArtStudents.Add(artStudent);
                }
                MartialArt.martialArts.RemoveAt(Id_Art);
                MartialArt.martialArts.Insert(Id_Art, martialArt);

                MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
                this.Close();
                martialArtsWindow.Show();
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
