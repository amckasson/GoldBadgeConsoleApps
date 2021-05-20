using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoBadges_Repository
{
    public class KomodoBadgesRepository
    {
        //private Dictionary<int, ListOfDoors> _KomodoBadges = new Dictionary<int, ListOfDoors>();
        private Dictionary<int, string> _KomodoBadges = new Dictionary<int, string>();

        public void AddBadgeToDictionary(KomodoBadges pair)
        {
            _KomodoBadges.Add(pair.BadgeID, pair.ListOfDoors);
        }

        //public Dictionary<KomodoBadges> GetBadgesDictionary()
        //{
            //_KomodoBadges.Values(pair.BadgeID, pair.ListOfDoors);
            //_KomodoBadges.Values();
            //foreach (KeyValuePair<int, string> badge in _KomodoBadges)
            //{
                //return badge
           // }
        //}
    }
}
