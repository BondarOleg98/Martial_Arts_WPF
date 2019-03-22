using System.Collections.Generic;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Relationship;
using System;

namespace Martial_Arts.Data.Sportsman
{
    [Serializable]
    public class Student : Person
    {
        private int yearsTraining;
        public Guid _coachId;
        public static List<Student> _students = new List<Student>();
        public static List<Student> Students = new List<Student>();

        public Student(int yearsTraining, string sportsmanStatus, string likeCompetition,
            string name, string surname, string belt, string sportTitle, int age, string country) :
            base(name, surname, belt, sportTitle, age, country)
        {
            YearsTraining = yearsTraining;
            SportsmanStatus = sportsmanStatus;
            LikeCompetition = likeCompetition;
        }

        //public Student(string name, string surname, string belt, int age, Coach coach) :
        //    base(name, surname, belt, age)
        //{
        //    Coach = coach;
        // }
        public Student()
        {

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

        //public Coach Coach { get; set; }

        public Coach Coach
        {
            get
            {
                foreach (Coach coach in Coach.coaches)
                    if (coach.Id == _coachId)
                        return coach;
                return null;
            }
            set
            {
                _coachId = value.Id;
            }
        }

        public List<MartialArt> MartialArts
        {
            get
            {
                List<MartialArt> result = new List<MartialArt>();
                foreach (ArtStudent sia in ArtStudent.ArtStudents)
                    if (sia.Student == this)
                        result.Add(sia.MartialArt);
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
        public override string ToString()
        {
            return Name +" "+ Surname;
        }
    }
}
