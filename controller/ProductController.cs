using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext;

[ApiController]
[Route("products")]
[EnableCors("AllowAnyOrigin")]
[ApiExplorerSettings(GroupName = "v1")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        var products = _productRepository.List();
        return Ok(products);
    }

    [HttpGet("{productId}")]
    public ActionResult<Product> GetProductById(int productId)
    {
        var product = _productRepository.GetById(productId);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost("create")]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Invalid product data");
        }

        try
        {
            _productRepository.Create(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

}
