using System;
using System.Collections.Generic;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Relationship;
using System.Linq;
using System.Xml.Serialization;

namespace Martial_Arts.Data.Sportsman
{
    [Serializable]
    public class Coach : Person
    {
        public static List<Coach> coaches = new List<Coach>();
        public static List<Student> students = new List<Student>();

        [NonSerialized]
        [XmlIgnore]
        private int countStudents;

        [NonSerialized]
        [XmlIgnore]
        private int yearStartCareer;
       // public Guid _studentId;
       // public Guid _clubId;
        public Coach(string name)
        {
            Name = name;
        }

        public Coach()
        {

        }
        [XmlIgnore]
        public int YearStartCareer
        {
            set
            {
                if (value < 1949)
                {
                    yearStartCareer = value;
                }
                else { yearStartCareer = value; }
            }
            get { return yearStartCareer; }
        }
        [XmlIgnore]
        public int CountStudents
        {
            set
            {
                if (value < 0)
                {
                    countStudents = 0;
                }
                else
                {
                    countStudents = value;
                }
            }
            get { return countStudents; }
        }
        [XmlIgnore]
        public string JudgeCategory { get; set; }

        public Coach(int countStudents, string judgeCategory, int yearStartCareer,
            string name, string surname, string belt, string sportTitle, int age, string country) :
            base(name, surname, belt, sportTitle, age, country)
        {
            CountStudents = countStudents;
            JudgeCategory = judgeCategory;
            YearStartCareer = yearStartCareer;

        }
        public Coach(string name, string surname, string belt, int age):
            base(name, surname, belt,  age )
        {

        }
       
        public List<Student> Students
        {
            get
            {
                List<Student> result = new List<Student>();
                foreach (Student st in Student._students)
                    if (st.Coach == this)
                        result.Add(st);
                return result;
            }

        }
       //// [XmlIgnore]
       // public Student student
       // {
       //     get
       //     {
       //         foreach (Student student in Student._students)
       //             if (student.Id == _studentId)
       //                 return student;
       //         return null;
       //     }
       //     set
       //     {
       //         _studentId = value.Id;
       //     }
       // }
        [XmlIgnore]
        public List<MartialArt> MaterialArts
        {
            get
            {
                List<MartialArt> result = new List<MartialArt>();
                foreach (ArtCoach cia in ArtCoach.ArtCoaches)
                    if (cia.coach == this)
                        result.Add(cia.MaterialArt);
                return result;
            }

        }
        [XmlIgnore]
        public List<ArtCoach> ArtCoaches
        {
            get
            {
                List<ArtCoach> result = new List<ArtCoach>();
                foreach (ArtCoach cia in ArtCoach.ArtCoaches)
                    if (cia.coach == this)
                        result.Add(cia);
                return result;
            }
        }
        [XmlIgnore]
        public List<Club> Clubs
        {
            get
            {
                List<Club> result = new List<Club>();
                foreach (Club cl in Club.Clubs)
                    if (cl.Coach == this)
                        result.Add(cl);
                return result;
            }

        }
        //[XmlIgnore]
        //public Club club
        //{
        //    get
        //    {
        //        foreach (Club club in Club.Clubs)
        //            if (club.Id == _clubId)
        //                return club;
        //        return null;
        //    }
        //    set
        //    {
        //        _clubId = value.Id;
        //    }
        //}

        public int CountClubs(List<Club> clubs)
        {
            int result = 0;
            result = clubs.Count();
            return result;
        }
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
