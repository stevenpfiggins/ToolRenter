using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRenter.Data
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        //public int ProfilePicture { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}
