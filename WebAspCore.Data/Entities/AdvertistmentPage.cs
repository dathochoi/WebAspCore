using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAspCore.Data.Entities
{
    [Table("AdvertistmentPages")]
    public class AdvertistmentPage 
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
