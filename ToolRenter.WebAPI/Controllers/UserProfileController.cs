using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolRenter.Models.UserProfile;
using ToolRenter.Services;

namespace ToolRenter.WebAPI.Controllers
{
    [Authorize]
    public class UserProfileController : ApiController
    {
        // GET ALL
        public IHttpActionResult GetAllUserProfiles()
        {
            UserProfileService userProfileService = CreateUserProfileService();
            var profiles = userProfileService.GetUserProfiles();

            return Ok(profiles);
        }

        // GET
        public IHttpActionResult GetUserProfilesById(int id)
        {
            UserProfileService userProfileService = CreateUserProfileService();
            var profiles = userProfileService.GetUserProfilesById(id);

            return Ok(profiles);
        }

        // POST
        [HttpPost]
        public IHttpActionResult CreateUserProfile(UserProfileCreate profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserProfileService();

            if (!service.CreateUserProfile(profile))
                return InternalServerError();

            return Ok();
        }

        // PUT
        [HttpPut]
        public IHttpActionResult EditUserProfile(UserProfileEdit profile)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserProfileService();

            if (!service.UpdateUserProfile(profile))
                return InternalServerError();

            return Ok();
        }

        // DELETE
        public IHttpActionResult DeleteUserProfile(int id)
        {
            var service = CreateUserProfileService();

            if (!service.DeleteUserProfile(id))
                return InternalServerError();

            return Ok();
        }

        private UserProfileService CreateUserProfileService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userProfileService = new UserProfileService(userId);
            return userProfileService;
        }
    }
}
