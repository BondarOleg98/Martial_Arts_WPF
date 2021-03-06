﻿using System;
using System.Collections.Generic;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Relationship;
using System.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Martial_Arts.Data.Sportsman
{
    [DataContract]
    
    public class Coach : Person
    {
        public static List<Coach> coaches = new List<Coach>();
        public static List<Student> students = new List<Student>();

       
        private int countStudents;

    
        private int yearStartCareer;
        public Coach(string name)
        {
            Name = name;
        }

        public Coach()
        {

        }
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
        public string JudgeCategory { get; set; }
        //[DataMember]
        //public List<Student> Students
        //{
        //    get
        //    {
        //        List<Student> result = new List<Student>();
        //        foreach (Student st in Student._students)
        //            if (st.Coach == this)
        //                result.Add(st);
        //        return result;
        //    }

        //}  
        //public List<MartialArt> MaterialArts
        //{
        //    get
        //    {
        //        List<MartialArt> result = new List<MartialArt>();
        //        foreach (ArtCoach cia in ArtCoach.ArtCoaches)
        //            if (cia.coach == this)
        //                result.Add(cia.MaterialArt);
        //        return result;
        //    }

        //}
        
        //public List<ArtCoach> ArtCoaches
        //{
        //    get
        //    {
        //        List<ArtCoach> result = new List<ArtCoach>();
        //        foreach (ArtCoach cia in ArtCoach.ArtCoaches)
        //            if (cia.coach == this)
        //                result.Add(cia);
        //        return result;
        //    }
        //}
 
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
