using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspCore.Models.ProductViewModels;

namespace WebAspCore.Models
{
    public class SearchResultViewModel : CatalogViewModel
    {
        public string Keyword { get; set; }
    }
}
