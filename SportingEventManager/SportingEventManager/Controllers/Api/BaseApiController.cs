using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using SportingEventManager.Dtos;
using SportingEventManager.Models;

namespace SportingEventManager.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult HandleException(Exception ex, string msg)
        {
            IHttpActionResult ret;

            // Create new exception with generic message        
            ret = StatusCode(                    
                StatusCodes.Status500InternalServerError, new Exception(msg, ex));

            return ret;
        }
    }
}
