using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Repository
{
    public enum ListOfDoors { A1 = 1, A2, A3, A4, A5, A6, A7,}
    public class KomodoBadges
    {
        public int BadgeID { get; set; }
        public ListOfDoors DoorsList { get; set; }

        public KomodoBadges() { }

        public KomodoBadges(int badgeID, ListOfDoors doorList)
        {
            BadgeID = badgeID;
            DoorsList = doorList;
        }
    }
}
