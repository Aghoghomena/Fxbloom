using FXBLOOM.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer.Controllers
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected new IActionResult Ok()
        {
            return base.Ok(ResponseWrapper.Ok());
        }

        /// <summary>
        /// Response for okay with result type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(ResponseWrapper.Ok(result));
        }

        /// <summary>
        /// Response for Conflict with result type T at all bussiness errors
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        protected IActionResult BussinessError<T>(T result)
        {
            return base.Conflict(ResponseWrapper.Ok(result));
        }

        /// <summary>
        /// Envelop for error messages
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(ResponseWrapper.Error(errorMessage));
        }

        /// <summary>
        /// Envelop for error messages
        /// </summary>
        /// <param name="errorMessages"></param>
        /// <returns></returns>
        protected IActionResult ErrorList(List<string> errorMessages)
        {
            return BadRequest(ResponseWrapper.ErrorList(errorMessages));
        }

        protected IActionResult UnAuthourized(string message)
        {
            return base.Unauthorized(ResponseWrapper.Unauthorized(message));
        }
    }
}
