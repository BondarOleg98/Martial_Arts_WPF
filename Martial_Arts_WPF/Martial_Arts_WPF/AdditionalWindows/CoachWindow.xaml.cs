using System.Linq;
using System.Windows;
using Martial_Arts.Data.Sportsman;
using Martial_Arts_WPF.DialogWindows;
using Martial_Arts.Data;
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
            listCoach.ItemsSource = Coach.coaches;
            listCoach.Items.Refresh();
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
            var coach = (Coach)listCoach.SelectedItem;
            Coach.coaches.Remove(coach);        
            listCoach.Items.Refresh();
            Coach.students.Clear();
            listStudents.ItemsSource = Coach.students;
            listStudents.Items.Refresh();

        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            int coach_Id = listCoach.SelectedIndex;
            var coach = (Coach)listCoach.SelectedItem;
            if (coach_Id ==-1 )
            {
                MessageBox.Show("Choose a coach");
            }
            else
            {
                CoachDialogWindow coachDialogWindow = new CoachDialogWindow(coach_Id, coach);
                coachDialogWindow.bt_Add.IsEnabled = false;
                this.Close();
                coachDialogWindow.Show();
            }    
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
          
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void Button_Show_Click(object sender, RoutedEventArgs e)
        {
            Coach.students.Clear();
            listStudents.ItemsSource = Coach.students;
            listStudents.Items.Refresh();
            var Coaches = (Coach)listCoach.SelectedItem;
            foreach (var item in Student._students)
            {
                if(item._coachId == Coaches.Id)
                {

                    Coach.students.Add(item);
                    listStudents.ItemsSource = Coach.students;
                    listStudents.Items.Refresh();
                }
                   
            }
        }
    }
}
