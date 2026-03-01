using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductCategoryId { get; set; } // Foreign key to ProductCategory
        public int ProductBrandId { get; set; } // Foreign key to ProductBrand
        public ProductCategory ProductCategory { get; set; } // Navigation property to ProductCategory
        public ProductBrand ProductBrand { get; set; }
    }
}
