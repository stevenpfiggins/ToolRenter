﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRenter.Models.UserProfile
{
    public class UserProfileCreate
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}
