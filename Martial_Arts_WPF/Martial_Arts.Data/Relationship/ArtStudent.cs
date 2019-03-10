using System;
using System.Collections.Generic;
using Martial_Arts.Data.Sportsman;
using Martial_Arts.Data.Structure;

namespace Martial_Arts.Data.Relationship
{
    public class ArtStudent
    {
        public static List<ArtStudent> ArtStudents = new List<ArtStudent>();

        private Guid _studentID;
        private Guid _artID;

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
        public MartialArt MaterialArt
        {
            get
            {
                foreach (MartialArt materialArt in MartialArt.materialArts)
                    if (materialArt.Id == _artID)
                        return materialArt;
                return null;

            }
            set
            {
                _artID = value.Id;
            }
        }
    }
}
