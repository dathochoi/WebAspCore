using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAspCore.Data.Entities
{
    [Table("MakeIns")]
    public class MakeIn
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool CheckMenu { get; set; }
        //public virtual ICollection<Product> Products { get; set; }


    }
}
