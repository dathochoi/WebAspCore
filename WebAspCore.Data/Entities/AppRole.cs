using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAspCore.Data.Entities
{
    public class AppRole: IdentityRole<Guid>
    {
        [StringLength(250)]
        public string Description { get; set; }
    }
}
