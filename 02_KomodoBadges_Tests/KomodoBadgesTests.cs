using _02_KomodoBadges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_KomodoBadges_Tests
{
    [TestClass]
    public class KomodoBadgesTests
    {
        [TestMethod]
        public void TestAdd()
        {
            KomodoBadges badges = new KomodoBadges();
            KomodoBadgesRepository repository = new KomodoBadgesRepository();

            bool addBadge = repository.AddBadgeToDictionary(badges.BadgeID, badges.ListOfDoors);

            Assert.IsTrue(addBadge);
        }

        [TestMethod]
        public void GetBadges()
        {
            KomodoBadges badges = new KomodoBadges();
            KomodoBadgesRepository repository = new KomodoBadgesRepository();

            bool addBadge = repository.AddBadgeToDictionary(badges.BadgeID, badges.ListOfDoors);

            
        }

       // private KomodoBadges _badge;
       // private KomodoBadgesRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            
        }
    }
}
