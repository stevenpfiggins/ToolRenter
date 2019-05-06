using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenter.Models.Request
{
    public class RequestListItem
    {
        public int RequestId { get; set; }

        [Display(Name="Equipment Requested")]
        public string EquipmentTypeRequested { get; set; }

        [Display(Name ="Begin Date")]
        public DateTimeOffset BeginningDateRequested { get; set; }

        [Display(Name ="End Date")]
        public DateTimeOffset EndingDateRequested { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
