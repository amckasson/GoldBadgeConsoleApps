using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Repository
{
    public class KomodoBadges
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoors { get; set; }

        public KomodoBadges() { }
        public KomodoBadges(int badgeID, List<string> doorList)
        {
            BadgeID = badgeID;
            ListOfDoors = doorList;
        }
    }
}
