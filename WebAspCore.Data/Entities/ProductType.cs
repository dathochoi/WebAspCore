using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebAspCore.Data.Enums;

namespace WebAspCore.Data.Entities
{
    [Table("ProductTypes")]
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int ProductId { get; set; }

        public bool Status { get; set; }
        public int Number { get; set; }

        public double OriginPrice { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
