using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Enums;

namespace WebAspCore.ViewModel.ViewModels.Products
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int ProductId { get; set; }

        public bool Status { get; set; }
        public int Number { get; set; }
        public double OriginPrice { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }

    }
}
