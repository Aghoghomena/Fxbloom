using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.SubsriptionAggregate;
using FXBLOOM.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class SubscriptionController : BaseController
    {


        private ISubscription _subscription;
        public SubscriptionController(ISubscription subscription)
        {
            //this is dependency injection
            _subscription = subscription;
        }

        [HttpGet]
        [Produces(typeof(ResponseWrapper<List<Subscription>>))]
        [Authorize]
        public IActionResult GetSubscribers()
        {
            return Ok(_subscription.GetSubscriptions());
        }

        [HttpPost]
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
