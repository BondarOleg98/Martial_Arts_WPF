using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Martial_Arts.Data;
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
            coachWindow.Owner = this;
            coachWindow.Show();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Student(object sender, RoutedEventArgs e)
        {
            StudenrWindow studenrWindow = new StudenrWindow();
            studenrWindow.Owner = this;
            studenrWindow.Show();
        }

        private void Button_Structure(object sender, RoutedEventArgs e)
        {
            StructureWindow structureWindow = new StructureWindow();
            structureWindow.Owner = this;
            structureWindow.Show();
        }
    }
}
