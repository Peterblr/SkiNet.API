using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(ProductSpecParams productParams)
        {
            var products = await context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .Where(p => (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search))
                    && (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId)
                    && (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
                .ToListAsync();

            products = productParams.Sort == null ? products : DoSort(products, productParams.Sort);

            PaginatedList<Product> paginatedProducts = new(products, productParams.PageIndex, productParams.PageSize);

            return paginatedProducts;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllProductBrandsAsync()
        {
            return await context.ProductBrands.ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            return await context.ProductTypes.ToListAsync();
        }

        private static List<Product> DoSort(List<Product> products, string sort)
        {
            products = sort switch
            {
                "nameDesc" => products.OrderByDescending(s => s.Name).ToList(),
                "price" => products.OrderBy(s => s.Price).ToList(),
                "priceDesc" => products.OrderByDescending(s => s.Price).ToList(),
                _ => products.OrderBy(s => s.Name).ToList(),
            };

            return products;
        }
    }
}
