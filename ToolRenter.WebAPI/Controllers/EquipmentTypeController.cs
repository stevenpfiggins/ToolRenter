using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolRenter.Services;

namespace ToolRenter.WebAPI.Controllers
{
    public class EquipmentTypeController : ApiController
    {
        //GET All Equipment Types

        private EquipmentTypeService CreateEquipmentTypeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new EquipmentTypeService(userId);

            return svc;
        }
    }
}
