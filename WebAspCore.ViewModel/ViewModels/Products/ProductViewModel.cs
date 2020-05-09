using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebAspCore.Data.Enums;

namespace WebAspCore.ViewModel.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        //[Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        public ProductCategoryViewModel ProductCategory { set; get; }

        public string SeoPageTitle { set; get; }

        [StringLength(255)]
        public string SeoAlias { set; get; }

        [StringLength(255)]
        public string SeoKeywords { set; get; }

        [StringLength(255)]
        public string SeoDescription { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public Status Status { set; get; }

        public int MakeInId { get; set; }
        public string MakeInName { get; set; }
        public MakeInViewModel MakeInViewModel { get; set; }
        public List<ProductTypeViewModel> ProductTypeList { get; set; }

        public List<ImageCheckViewModel> ImageList = new List<ImageCheckViewModel>();
    }
}
