using Max.Framework.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Models.Home
{
    public class CustomerValidation
    {
        [Required]
        [StringLength(2)]
        public string Account { get; set; }

        [Required]
        [CharacterLength(2)]
        public string UserName { get; set; }
    }
}