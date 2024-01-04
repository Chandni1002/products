// ProductCategoryController.cs
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/productCategories")]
[EnableCors("AllowAnyOrigin")]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryRepository _categoryRepository;

    public ProductCategoryController(IProductCategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] ProductCategory category)
    {
        if (category == null)
        {
            return BadRequest("Invalid product category data");
        }

        try
        {
            _categoryRepository.Create(category);
            return Ok("Product category created successfully");
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }
}