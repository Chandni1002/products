public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public List<ProductCategory> Categories { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
