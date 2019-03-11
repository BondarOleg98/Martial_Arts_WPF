using System.Windows;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.AdditionalWindows;
using System;

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
                martialArt.Name = textName.Text;
             
                //if (listStudents.SelectedItem == null)
                //{
                //    MessageBox.Show("Choose a coach");
                //}

                MartialArt.martialArts.Add(martialArt);
                MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
                this.Close();
                martialArtsWindow.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
