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
        public Dictionary<int, string> GetBadges()
        {
            return _KomodoBadges;
        }

        public void UpdateExistingBadge(int originalID, string doorList)
        {
            KomodoBadges oldBadge = GetBadges(int , string)
        }




        //private KomodoBadges GetBadgeByID(int, string badgeID)
        //{
        //    foreach(KeyValuePair<int, string> badge in _KomodoBadges)
        //    {
        //        if (badge.Key == badgeID)
        //        {
        //           return badge.Key badge.Value;
        //        }
        //    }
        //}
        // Testing this push
        public void Worried()
        {
            Console.WriteLine("Whats going on?");
        }
    }
}
