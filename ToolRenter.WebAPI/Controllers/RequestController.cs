using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolRenter.Models.Request;
using ToolRenter.Services;

namespace ToolRenter.WebAPI.Controllers
{
    [Authorize]
    public class RequestController : ApiController
    {
        // GET ALL
        public IHttpActionResult GetAllRequests()
        {
            RequestService requestService = CreateRequestService();
            var requests = requestService.GetRequests();

            return Ok(requests);
        }

        // GET
        public IHttpActionResult GetRequestById(int id)
        {
            RequestService requestService = CreateRequestService();
            var request = requestService.GetRequestById(id);

            return Ok(request);
        }

        // POST
        public IHttpActionResult CreateRequest(RequestCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRequestService();

            if (!service.CreateRequest(request))
                return InternalServerError();

            return Ok();
        }

        // PUT
        public IHttpActionResult EditRequest(RequestEdit request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRequestService();

            if (!service.UpdateRequest(request))
                return InternalServerError();

            return Ok();
        }

        // DELETE
        public IHttpActionResult DeleteRequest(int id)
        {
            var service = CreateRequestService();

            if (!service.DeleteRequest(id))
                return InternalServerError();

            return Ok();
        }

        private RequestService CreateRequestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var requestService = new RequestService(userId);
            return requestService;
        }
    }
}
