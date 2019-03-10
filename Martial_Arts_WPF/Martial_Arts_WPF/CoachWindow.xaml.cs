using System.Windows;
using System.Windows.Controls;
using Martial_Arts.Data.Sportsman;
namespace Martial_Arts_WPF
{
    /// <summary>
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window
    {
        public CoachWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = textName.Text;
            Coach coach = new Coach(text, "", "", "", 12, "");
            Coach.coaches.Add(coach);
            listCoach.ItemsSource = Coach.coaches;
            listCoach.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var coach = (Coach)listCoach.SelectedItem;
            Coach.coaches.Remove(coach);
            listCoach.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int coach = listCoach.SelectedIndex;
            Coach.coaches.RemoveAt(coach);
            Coach.coaches.Insert(coach, new Coach(textName.Text, "", "", "", 12, ""));
           
            listCoach.Items.Refresh();
        }
    }
}
