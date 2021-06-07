using FXBLOOM.DataLayer.Interface;
using FXBLOOM.DomainLayer.SubsriptionAggregate;
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
    public class SubscriptionController : ControllerBase
    {


        private ISubscription _subscription;
        public SubscriptionController(ISubscription subscription)
        {
            //this is dependency injection
            _subscription = subscription;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult getEmployees()
        {
            return Ok(_subscription.GetSubscriptions());
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateSubscription(Subscription sub)
        {

            try
            {
                //validate email
                var existing = _subscription.GetSingleSubscription(sub.email);
                if (existing == null)
                {
                    _subscription.AddSubscription(sub);

                    var status = "Success";
                    return Ok(status);
                }
                else
                {
                    return BadRequest($"Email {sub.email} exists");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
