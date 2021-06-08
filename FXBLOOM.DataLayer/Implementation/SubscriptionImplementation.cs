using FXBLOOM.DataLayer.Context;
using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.SubsriptionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FXBLOOM.DataLayer.Implementation
{
    public class SubscriptionImplementation: ManagerBase<Subscription>, ISubscription
    {
        private FXBloomContext _context;
        public SubscriptionImplementation(FXBloomContext context) : base(context)
        {
            _context = context;
        }

        public bool AddSubscription(Subscription sub)
        {
            _context.Subscriptions.Add(sub);
            int res = _context.SaveChanges();
            return res > 0 ? true : false;
        }

        public Subscription GetSingleSubscription(string email)
        {
            var existing = _context.Subscriptions.Where(c => c.email == email).FirstOrDefault();
            return existing;

        }

        public List<Subscription> GetSubscriptions()
        {
            return _context.Subscriptions.ToList();
        }

    }
}
