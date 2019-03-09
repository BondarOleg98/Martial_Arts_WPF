using System;
using System.Collections.Generic;
using Martial_Arts.Data.Structure;
using Martial_Arts.Data.Sportsman;
using System.Linq;

namespace Martial_Arts.Data.Relationship
{
    class ArtCoach
    {
        public static List<ArtCoach> ArtCoaches = new List<ArtCoach>();

        private Guid _coachID;
        private Guid _artID;

        public Coach coach
        {
            get
            {
                foreach (Coach coach in Coach.coaches)
                    if (coach.Id == _coachID)
                        return coach;
                return null;

            }
            set
            {
                _coachID = value.Id;
            }
        }

        public int Clubs(List<Club> clubs)
        {
            int result = 0;
            result = clubs.Count();
            return result;
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
