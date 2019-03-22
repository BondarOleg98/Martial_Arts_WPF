using System;
using System.Collections.Generic;
using Martial_Arts.Data.Sportsman;
using Martial_Arts.Data.Relationship;

namespace Martial_Arts.Data.Structure
{
    [Serializable]
    public class MartialArt : Base
    {
        public static List<MartialArt> martialArts = new List<MartialArt>();
        public static List<MartialArt> _martialArts = new List<MartialArt>();
        public Guid _fedId;
        private int countCountry;
        public MartialArt()
        {

        }
        public int CountCountry
        {
            set
            {
                if (value < 0)
                {
                    countCountry = 0;
                }
                else { countCountry = value; }
            }
        }
        public string Name { get; set; }

        public MartialArt(string name, int countCountry)
        {
            Name = name;
            CountCountry = countCountry;
        }

        public List<Coach> Coaches
        {
            get
            {
                List<Coach> result = new List<Coach>();
                foreach (ArtCoach cia in ArtCoach.ArtCoaches)
                    if (cia.MaterialArt == this)
                        result.Add(cia.coach);
                return result;
            }

        }

        public List<Student> Students
        {
            get
            {
                List<Student> result = new List<Student>();
                foreach (ArtStudent cia in ArtStudent.ArtStudents)
                    if (cia.MartialArt == this)
                        result.Add(cia.Student);
                return result;
            }

        }

        public List<ArtCoach> ArtCoaches
        {
            get
            {
                List<ArtCoach> result = new List<ArtCoach>();
                foreach (ArtCoach cia in ArtCoach.ArtCoaches)
                    if (cia.MaterialArt == this)
                        result.Add(cia);
                return result;
            }
        }
        public List<ArtStudent> ArtStudents
        {
            get
            {
                List<ArtStudent> result = new List<ArtStudent>();
                foreach (ArtStudent sia in ArtStudent.ArtStudents)
                    if (sia.MartialArt == this)
                        result.Add(sia);
                return result;
            }
        }

        public List<Federation> Federations
        {
            get
            {
                List<Federation> result = new List<Federation>();
                foreach (Federation fed in Federation.Federations)
                    if (fed.MartialArt == this)
                        result.Add(fed);
                return result;
            }

        }
        public Federation federation
        {
            get
            {
                foreach (Federation fed in Federation.Federations)
                    if (fed.Id == _fedId)
                        return fed;
                return null;
            }
            set
            {
                _fedId = value.Id;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
