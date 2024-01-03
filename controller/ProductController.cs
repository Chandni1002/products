using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        _repository.Create(product);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        var existingProduct = _repository.GetById(id);
        if (existingProduct == null)
            return NotFound();

        existingProduct.ProductName = product.ProductName;
        existingProduct.Categories = product.Categories;
        existingProduct.Cost = product.Cost;
        existingProduct.Description = product.Description;
        existingProduct.IsActive = product.IsActive;

        _repository.Update(existingProduct);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _repository.List();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _repository.GetById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _repository.GetById(id);
        if (product == null)
            return NotFound();

        _repository.Delete(product);
        return Ok();
    }
}
