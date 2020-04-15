using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAspCore.Data.Entities
{
    [Table("BlogTags")]
    public class BlogTag
    {
        [Key]
        [StringLength(250)]
        [Required]
        public int BlogId { set; get; }


        [StringLength(50)]
        [Required]
        public string TagId { set; get; }

        [ForeignKey("BlogId")]
        public virtual Blog Blog { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }

}