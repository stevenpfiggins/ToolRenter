using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolRenter.Models.Equipment;
using ToolRenter.Services;

namespace ToolRenter.WebAPI.Controllers
{
    public class EquipmentController : ApiController
    {
        //GET All Equipment
        public IHttpActionResult Get()
        {
            EquipmentService equipmentService = CreateEquipmentService();
            var equipment = equipmentService.GetEquipment();
            return Ok(equipment);
        }

        //GET Equipment by Id
        public IHttpActionResult Get(int id)
        {
            EquipmentService svc = CreateEquipmentService();
            var equipment = svc.GetEquipmentById(id);

            return Ok(equipment);
        }

        //POST Equipment Create
        [HttpPost]
        public IHttpActionResult CreateInvoice(EquipmentCreate equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateEquipmentService();

            if (!svc.CreateEquipment(equipment))
                return InternalServerError();

            return Ok("201");
        }

        //PUT Equipment Edit

        //DELETE Equipment Delete
        public IHttpActionResult DeleteEquipment(int id)
        {
            var svc = CreateEquipmentService();

            if (!svc.DeleteEquipment(id))
                return InternalServerError();

            return Ok("202");
        }

        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new EquipmentService(userId);

            return svc;
        }
    }
}
