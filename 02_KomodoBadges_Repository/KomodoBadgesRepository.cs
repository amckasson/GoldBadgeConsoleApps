using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Repository
{
    public class KomodoBadgesRepository
    {
        private Dictionary<int, KomodoBadges> _KomodoBadges = new Dictionary<int, KomodoBadges>();

        //Create
        public void AddBadgeToDictionary(int badgeID, KomodoBadges doorAccess)
        {
            _KomodoBadges.Add(badgeID, doorAccess);
        }

        //Read
        public Dictionary<int, KomodoBadges> GetBadges()
        {
            return _KomodoBadges;
        }

        //Update
        public void UpdateExistingBadge(int originalID, KomodoBadges doorList)
        {
           
        }

    }
}
