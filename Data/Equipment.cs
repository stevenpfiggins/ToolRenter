using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenter.Data
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int EquipmentTypeId { get; set; }

        [Required]
        public string EquipmentName { get; set; }

        [Required]
        public string EquipmentDescription { get; set; }

        [Required]
        public decimal EquipmentRate { get; set; }

        [Required]
        public string PhotoUpload { get; set; }
    }
}
