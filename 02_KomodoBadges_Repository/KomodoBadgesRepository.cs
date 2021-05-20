using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Repository
{
    public class KomodoBadgesRepository
    {
        private Dictionary<int, List<string>> _KomodoBadges = new Dictionary<int, List<string>>();

        //Create
        public bool AddBadgeToDictionary(int badgeID, List<string> doorAccess)
        {
            //Dictionary<int, List<string>> oldList = _KomodoBadges;
            _KomodoBadges.Add(badgeID, doorAccess);
            return _KomodoBadges.ContainsKey(badgeID);
        }

        //Read
        public Dictionary<int, List<string>> GetBadges()
        {
            return _KomodoBadges;
        }

        //Update
        public bool AddDoorToBadge(int originalID, string doorAdd)
        {
            KomodoBadges oldBadge = GetBadgeByID(originalID);
            if (oldBadge.ListOfDoors.Contains(doorAdd))
            {
                return false;
            }
            else
            {
                oldBadge.ListOfDoors.Add(doorAdd);
                _KomodoBadges[originalID] = oldBadge.ListOfDoors;
                return true;
            }
        }

        public bool RemoveDoorFromBadge(int originalID, string doorRemove)
        {
            KomodoBadges oldBadge = GetBadgeByID(originalID);
            if (oldBadge.ListOfDoors.Contains(doorRemove))
            {
                oldBadge.ListOfDoors.Remove(doorRemove);
                _KomodoBadges[originalID] = oldBadge.ListOfDoors;
                return true;
            }
            else
            {
                return false;
            }
        }


        public KomodoBadges GetBadgeByID(int badgeID)
        {
            return new KomodoBadges(badgeID, _KomodoBadges[badgeID]);
        }
    }
}
