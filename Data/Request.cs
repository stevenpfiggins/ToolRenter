using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToolRenter.Data
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public DateTimeOffset BeginningDateRequested { get; set; }

        [Required]
        public DateTimeOffset EndingDateRequested { get; set; }
    }
}
