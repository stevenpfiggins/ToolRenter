using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web;

namespace ToolRenter.Models.Equipment
{
    public class EquipmentCreate
    {
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public int EquipmentTypeId { get; set; }
        public decimal EquipmentRate { get; set; }
        public HttpPostedFileBase PhotoUpload { get; set; }
    }
}
