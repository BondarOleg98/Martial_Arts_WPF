using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Martial_Arts.Data.Sportsman;
using Martial_Arts.Data.Structure;

namespace Martial_Arts.Data.Relationship
{
    [DataContract]
    public class ArtStudent
    {
        public static List<ArtStudent> ArtStudents = new List<ArtStudent>();

        public static List<ArtStudent> _ArtStudents = new List<ArtStudent>();

        public ArtStudent()
        {

        }
        public Guid _studentID;
        public Guid _artID;

        //[DataMember]
        //public Student Student
        //{
        //    get
        //    {
        //        foreach (Student student in Student._students)
        //            if (student.Id == _studentID)
        //                return student;
        //        return null;

        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            _studentID = value.Id;
        //        }
        //    }
        //}
        [DataMember]
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
                if (value != null)
                {
                    _artID = value.Id;
                }             
            }
        }
    
    }
}
