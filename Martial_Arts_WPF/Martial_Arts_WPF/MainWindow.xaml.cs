using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using Martial_Arts.Data;
using Martial_Arts.Data.Relationship;
using Martial_Arts.Data.Sportsman;
using Martial_Arts.Data.Structure;
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
            //XmlSerializer xmlSerializerStudent = new XmlSerializer(typeof(List<Student>));
            //DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(List<Coach>));
            //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<MartialArt>));

            //using (FileStream fs = new FileStream("student.xml", FileMode.Open))
            //{
            //    Student._students = (List<Student>)xmlSerializerStudent.Deserialize(fs);
            //}
            //using (FileStream fs = new FileStream("coach.xml", FileMode.Open))
            //{
            //    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            //    Coach.coaches = (List<Coach>)dataContractSerializer.ReadObject(reader, true);
            //}
            //using (FileStream fs = new FileStream("martial_art.json", FileMode.Open))
            //{
            //    MartialArt.martialArts = (List<MartialArt>)jsonSerializer.ReadObject(fs);
            //}
            //DataContractJsonSerializer jsonArtStudent = new DataContractJsonSerializer(typeof(List<ArtStudent>));
            //using (FileStream fs = new FileStream("art_st.json", FileMode.Open))
            //{
            //    ArtStudent.ArtStudents = (List<ArtStudent>)jsonArtStudent.ReadObject(fs);
            //}

        }
        public MainWindow(int flag)
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

            XmlSerializer xmlSerializerStudent = new XmlSerializer(typeof(List<Student>));
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(List<Coach>));
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<MartialArt>));

            using (FileStream fs = new FileStream("student.xml", FileMode.Create))
            {
                xmlSerializerStudent.Serialize(fs, Student._students);
            }

            using (FileStream writer = new FileStream("coach.xml", FileMode.Create))
            {
                dataContractSerializer.WriteObject(writer, Coach.coaches);
            }

            using (FileStream fs = new FileStream("martial_art.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, MartialArt.martialArts);
            }


            DataContractJsonSerializer jsonArtStudent = new DataContractJsonSerializer(typeof(List<ArtStudent>));
            using (FileStream fs = new FileStream("art_st.json", FileMode.Create))
            {
                jsonArtStudent.WriteObject(fs, ArtStudent.ArtStudents);
            }
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
            MartialArtsWindow martialArtsWindow = new MartialArtsWindow();
           
            martialArtsWindow.Show();
            this.Close();
        }
    }
}
