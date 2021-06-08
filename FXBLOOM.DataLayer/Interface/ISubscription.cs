using FXBLOOM.DomainLayer.SubsriptionAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.DataLayer.Interface
{
    public interface ISubscription
    {
        //get all subscription
        List<Subscription> GetSubscriptions();

        //get single employee
        Subscription GetSingleSubscription(string email);

        //create employee
        bool AddSubscription(Subscription sub);

        //delete employee
        //void DeleteSubscription(Subscription sub);

        //edit employee data
        //Employee EditSubscription(Subscription sub);

    }
}
