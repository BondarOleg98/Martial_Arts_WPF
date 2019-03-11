using System;
using System.Collections.Generic;
using Martial_Arts.Data.Sportsman;
using Martial_Arts.Data.Structure;

namespace Martial_Arts.Data.Relationship
{
    public class ArtStudent
    {
        public static List<ArtStudent> ArtStudents = new List<ArtStudent>();
        //public static List<ArtStudent> _ArtStudents = new List<ArtStudent>();

        public static List<MartialArt> _martialArts = new List<MartialArt>();
        public Guid _studentID;
        public Guid _artID;

        public Student Student
        {
            get
            {
                foreach (Student student in Student._students)
                    if (student.Id == _studentID)
                        return student;
                return null;

            }
            set
            {
                _studentID = value.Id;
            }
        }
        public MartialArt MartialArt
        {
            get
            {
                foreach (MartialArt martialArt in MartialArt.martialArts)
                    if (martialArt.Id == _artID)
                        return martialArt;
                return null;

            }
            set
            {
                _artID = value.Id;
            }
        }
    
    }
}
