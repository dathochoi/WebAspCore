using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAspCore.Data.Entities
{
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR(50)")]
        public string Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }


        //public virtual ICollection<Product> Products { get; set; }
    }
}
