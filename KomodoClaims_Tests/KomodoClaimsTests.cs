using KomodoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaims_Tests
{
    [TestClass]
    public class KomodoClaimsTests
    {
        private KomodoClaimsRepository _repo;
        private KomodoClaims _claims;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new KomodoClaimsRepository();
            _claims = new KomodoClaims(123, ClaimType.Car, "Car crash", 2300.50m, DateTime.Now, DateTime.Now, true);

            _repo.AddClaimToQueue(_claims);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            KomodoClaims claim = new KomodoClaims();
            claim.ClaimID = 12345;
            KomodoClaimsRepository repository = new KomodoClaimsRepository();

            repository.AddClaimToQueue(claim);
            KomodoClaims claimFromDirectory = repository.GetClaimByID(12345);

            Assert.IsNotNull(claimFromDirectory);
        }

        //[TestMethod]
        //public void DeleteClaim_ShouldReturnTrue()
        //{
        //    bool deleteResult = _repo.RemoveClaimQueue();

        //    Assert.IsTrue(deleteResult);
        //}

        [TestMethod]
        public void Dequeue()
        {
           _repo.RemoveClaimQueue();

            //Assert.IsTrue(wasDeleted);
        }
    }
}
