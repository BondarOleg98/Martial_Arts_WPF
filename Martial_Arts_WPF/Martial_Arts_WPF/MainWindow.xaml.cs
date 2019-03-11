using System.Windows;
using Martial_Arts_WPF.AdditionalWindows;
namespace Martial_Arts_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
            
        }

        private void Button_Coach(object sender, RoutedEventArgs e)
        {
            CoachWindow coachWindow = new CoachWindow();
            this.Close();
            coachWindow.Show();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Student(object sender, RoutedEventArgs e)
        {
            StudentWindow studenrWindow = new StudentWindow();
            this.Close();
            studenrWindow.Show();
        }

        private void Button_Structure(object sender, RoutedEventArgs e)
        {
            StructureWindow structureWindow = new StructureWindow();
            this.Close();
            structureWindow.Show();
        }
    }
}
