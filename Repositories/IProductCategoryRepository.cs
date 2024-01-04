//IProductCategoryRepository.cs
public interface IProductCategoryRepository
{
    void Create(ProductCategory category);
    void Update(ProductCategory category);
    List<ProductCategory> List();
    ProductCategory GetById(int id);
    void Delete(ProductCategory category);
}