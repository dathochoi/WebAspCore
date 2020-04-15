using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAspCore.Data.Entities
{
    [Table("Footers")]
    public class Footer 
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        public string Id { get; set; }

        [Required]
        public string Content { set; get; }
    }
}
