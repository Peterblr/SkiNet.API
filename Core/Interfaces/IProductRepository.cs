using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync(string? sort);
        Task<IEnumerable<ProductBrand>> GetAllProductBrandsAsync();
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();
    }
}
