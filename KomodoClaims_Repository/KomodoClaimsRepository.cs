using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class KomodoClaimsRepository
    {
        private Queue<KomodoClaims> _queueOfClaims = new Queue<KomodoClaims>();

        public void AddClaimToQueue(KomodoClaims claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

        public Queue<KomodoClaims> GetClaimsQueue()
        {
            return _queueOfClaims;
        }

        public bool UpdateExistingClaim(int originalClaim, KomodoClaims newClaim)
        {
            KomodoClaims oldClaim = GetClaimByID(originalClaim);

            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.IsValid = newClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveClaimQueue()
        {
            _queueOfClaims.Dequeue();
        }
        
        //Helper
        public KomodoClaims GetClaimByID(int iD)
        {
            foreach (KomodoClaims claim in _queueOfClaims)
            {
                if (claim.ClaimID == iD)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
