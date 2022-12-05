namespace Core.Entities
{
    public class Product : BaseEntity
    {        
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public ProductType ProductType { get; set; } = new ProductType();
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; } = new ProductBrand();
        public int ProductBrandId { get; set; }
    }
}
