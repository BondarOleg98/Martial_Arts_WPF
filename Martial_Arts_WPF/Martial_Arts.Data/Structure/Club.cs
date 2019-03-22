using System.Collections.Generic;
using Martial_Arts.Data.Sportsman;

namespace Martial_Arts.Data.Structure
{
    public class Club : Base
    {
        public static List<Club> Clubs = new List<Club>();
        public string Name { get; set; }
        public string Address { get; set; }

        public Club(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public Club()
        {

        }
        public Coach Coach { get; }
        public Federation Federation { get; }

    }
}
