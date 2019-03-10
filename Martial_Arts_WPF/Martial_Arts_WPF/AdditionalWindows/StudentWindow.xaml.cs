using System.Windows;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data.Sportsman;
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
            listStudent.ItemsSource = Student.students;
            listStudent.Items.Refresh();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            StudentDialogWindow studentDialogWindow = new StudentDialogWindow();
           // studentDialogWindow.bt_Edit.IsEnabled = false;
            this.Close();
            studentDialogWindow.Show();
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
