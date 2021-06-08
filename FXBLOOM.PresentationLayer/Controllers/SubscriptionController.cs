using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.SubsriptionAggregate;
using FXBLOOM.SharedKernel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer.Controllers
{

    [ApiController]
    public class SubscriptionController : BaseController
    {


        private ISubscription _subscription;
        public SubscriptionController(ISubscription subscription)
        {
            //this is dependency injection
            _subscription = subscription;
        }

        [HttpGet]
        [Route("api/[controller]")]
        [Produces(typeof(ResponseWrapper<List<Subscription>>))]
        public IActionResult getEmployees()
        {
            return Ok(_subscription.GetSubscriptions());
        }

        [HttpPost]
        [Route("api/[controller]")]
        [Produces(typeof(ResponseWrapper<string>))]
        public IActionResult CreateSubscription(Subscription sub)
        {

            var existing = _subscription.GetSingleSubscription(sub.email);
            if (existing != null)
            {
                return BadRequest($"Email {sub.email} exists");
            }

            bool response = _subscription.AddSubscription(sub);
            if(response is false)
            {
                return Error("Oops something went wrong. Try again.");
            }

            return Ok("Email saved successfully.");
        }

    }

}
