using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenter.Models.Request
{
    public class RequestDetail
    {
        public int RequestId { get; set; }

        [Display(Name ="Name")]
        public string EquipmentTypeRequested { get; set; }

        [Display(Name ="Start Date")]
        public DateTimeOffset BeginningDateRequested { get; set; }

        [Display(Name ="End Date")]
        public DateTimeOffset EndingDateRequested { get; set; }
    }
}
