using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolRenter.Models.EquipmentType;
using ToolRenter.Services;

namespace ToolRenter.WebAPI.Controllers
{
    //[Authorize Admin]
    public class EquipmentTypeController : ApiController
    {
        //GET All Equipment Types
        public IHttpActionResult Get()
        {
            var svc = new EquipmentTypeService();
            var equipmentType = svc.GetEquipmentType();
            return Ok(equipmentType);
        }

        //GET Equipment Type by Id
        public IHttpActionResult Get(int id)
        {
            var svc = new EquipmentTypeService();
            var equipmentType = svc.GetEquipmentTypeById(id);

            return Ok(equipmentType);
        }

        //POST Equipment Type Create
        [HttpPost]
        public IHttpActionResult CreateEquipmentType(EquipmentTypeCreate equipmentType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = new EquipmentTypeService();

            if (!svc.CreateEquipmentType(equipmentType))
                return InternalServerError();

            return Ok("201");
        }

        //PUT Equipment Type Edit
        [HttpPut]
        public IHttpActionResult EquipmentTypeEdit(EquipmentTypeEdit equipmentType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = new EquipmentTypeService();

            if (!svc.UpdateEquipment(equipmentType))
                return InternalServerError();

            return Ok("207");
        }

        //DELETE Equipment Type Delete
        public IHttpActionResult DeleteEquipment(int id)
        {
            var svc = new EquipmentTypeService();

            if (!svc.DeleteEquipmentType(id))
                return InternalServerError();

            return Ok("202");
        }

        //private EquipmentTypeService CreateEquipmentTypeService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var svc = new EquipmentTypeService(userId);

        //    return svc;
        //}
    }
}
