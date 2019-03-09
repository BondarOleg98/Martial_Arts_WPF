using System.Collections.Generic;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Relationship;



namespace Martial_Arts.Data.Sportsman
{
    class Student : Person
    {
        private int yearsTraining;
        public static List<Student> students = new List<Student>();
        public static List<Student> _students = new List<Student>();

        public Student(int yearsTraining, string sportsmanStatus, string likeCompetition,
            string name, string surname, string belt, string sportTitle, int age, string country) :
            base(name, surname, belt, sportTitle, age, country)
        {
            YearsTraining = yearsTraining;
            SportsmanStatus = sportsmanStatus;
            LikeCompetition = likeCompetition;
        }

        public string LikeCompetition { get; set; }
        public string SportsmanStatus { get; set; }
        public int YearsTraining
        {
            set
            {
                if (value < 0)
                {
                    yearsTraining = value;
                }
                else { yearsTraining = value; }
            }
            get { return yearsTraining; }
        }

        public Coach Coach { get; }


        public List<MartialArt> MaterialArts
        {
            get
            {
                List<MartialArt> result = new List<MartialArt>();
                foreach (ArtStudent sia in ArtStudent.ArtStudents)
                    if (sia.Student == this)
                        result.Add(sia.MaterialArt);
                return result;
            }

        }
        public List<ArtStudent> ArtStudents
        {
            get
            {
                List<ArtStudent> result = new List<ArtStudent>();
                foreach (ArtStudent cia in ArtStudent.ArtStudents)
                    if (cia.Student == this)
                        result.Add(cia);
                return result;
            }
        }
    }
}
