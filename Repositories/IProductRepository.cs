public interface IProductRepository
{
    void Create(Product product);
    void Update(Product product);
    List<Product> List();
    Product GetById(int id);
    void Delete(Product product);
}