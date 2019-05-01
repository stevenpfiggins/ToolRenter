using System;
using System.Collections.Generic;
using System.Text;

namespace ToolRenter.Models.Equipment
{
    public class EquipmentEdit
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public decimal EquipmentRate { get; set; }
    }
}
