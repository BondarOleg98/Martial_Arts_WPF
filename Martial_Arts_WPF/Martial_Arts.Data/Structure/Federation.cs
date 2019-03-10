using System;
using System.Collections.Generic;
using Martial_Arts.Data.Structure;

namespace Martial_Arts.Data.Structure
{
    public class Federation : Base
    {
        public static List<Federation> Federations = new List<Federation>();
        private int countCoaches;
        private int countStudents;
        public Guid _clubId;
        public string NamePresident { get; set; }
        public string Name { get; set; }
        public int CountCoaches
        {
            set
            {
                if (value < 0)
                {
                    countCoaches = value;
                }
                else { countCoaches = value; }
            }
        }

        public int CountStudents
        {
            set
            {
                if (value < 0)
                {
                    countStudents = value;
                }
                else { countStudents = value; }
            }
        }
        public Federation(int countCoaches, int countStudents, string namePresident, string name)
        {
            Name = name;
            NamePresident = namePresident;
            CountCoaches = countCoaches;
            CountStudents = countStudents;
        }

        public MartialArt MartialArt { get; }

        public List<Club> Clubs
        {
            get
            {
                List<Club> result = new List<Club>();
                foreach (Club cl in Club.Clubs)
                    if (cl.Federation == this)
                        result.Add(cl);
                return result;
            }

        }
        public Club Club
        {
            get
            {
                foreach (Club club in Club.Clubs)
                    if (club.Id == _clubId)
                        return club;
                return null;
            }
            set
            {
                _clubId = value.Id;
            }
        }
    }
}
