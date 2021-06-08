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

        public Subscription AddSubscription(Subscription sub)
        {
            //validate the email
            _context.Subscriptions.Add(sub);
            _context.SaveChanges();
            return sub;
        }

        public Subscription GetSingleSubscription(string email)
        {
            var existing = _context.Subscriptions.Where(c => c.email == email).FirstOrDefault();
            return existing;

        }

        //public void DeleteSubscription(Subscription sub)
        //{
        //    //throw new NotImplementedException();
        //    var existing = _subContext.Subscriptions.Find(sub.email);
        //    if (existing != null)
        //    {
        //        _subContext.Subscriptions.Remove(existing);
        //        _subContext.SaveChanges();
        //    }
        //}

        //public Employee EditSubscription(Subscription sub)
        //{
        //    throw new NotImplementedException();
        //}

        //public Subscription GetSingleSubscription(string email)
        //{
        //    var existing = _subContext.Subscriptions.Where(c => c.email == email).FirstOrDefault();
        //    return existing;

        //}

        public List<Subscription> GetSubscriptions()
        {
            return _context.Subscriptions.ToList();
        }

    }
}
