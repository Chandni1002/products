public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public List<Product> List()
    {
        return _context.Products.ToList();
    }

    public Product GetById(int id)
    {
        return _context.Products.Find(id);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}
