using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string? sort)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            //AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nameDesc":
                        AddOrderByDescending(s => s.Name);
                        break;
                    case "price":
                        AddOrderBy(s => s.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(s => s.Price);
                        break;
                    default:
                        AddOrderBy(s => s.Name);
                        break;
                };
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
