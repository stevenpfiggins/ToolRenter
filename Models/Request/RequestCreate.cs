using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenter.Models.Request
{
    public class RequestCreate
    {
        public int EquipmentId { get; set; }

        [Required]
        [Display(Name ="Start Date")]
        public DateTimeOffset BeginningDateRequested { get; set; }

        [Required]
        [Display(Name ="End Date")]
        public DateTimeOffset EndingDateRequested { get; set; }
    }
}
