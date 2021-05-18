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

        public void RemoveClaimQueue()
        {
            _queueOfClaims.Dequeue();
        }

        //Below are failed tests that dont work

        //public Queue<KomodoClaims> RemoveClaimFromQueue()
        //{
        //    _queueOfClaims.Dequeue();
        //    return _queueOfClaims;
        //}

        //public void RemoveClaimFromQueue(KomodoClaims claim)
        //{
        //    _queueOfClaims.Dequeue();
        //    _queueOfClaims.Count > 0
        //}

        //public bool RemoveClaimFromQueue(int iD)
        //{
        //    KomodoClaims claim = GetClaimByID(iD);

        //    if (claim == null)
        //    {
        //        return false;
        //    }
        //    int initialCount = _queueOfClaims.Count;
        //    _queueOfClaims.Dequeue(claim);
        //}


        //Helper may not be needed

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
