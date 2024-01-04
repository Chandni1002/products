public class ProductCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }

    // Navigation property for Products
    public List<Product> Products { get; set; }
}