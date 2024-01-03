
// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("[controller]")]
// public class ProductCategoryController : ControllerBase
// {
//     private readonly IProductCategoryRepository _repository;

//     public ProductCategoryController(IProductCategoryRepository repository)
//     {
//         _repository = repository;
//     }

//     [HttpPost]
//     public IActionResult CreateProductCategory(ProductCategory productCategory)
//     {
//         _repository.Create(productCategory);
//         return Ok();
//     }

//     [HttpPut("{id}")]
//     public IActionResult UpdateProductCategory(int id, ProductCategory productCategory)
//     {
//         var existingCategory = _repository.GetById(id);
//         if (existingCategory == null)
//             return NotFound();

//         existingCategory.CategoryName = productCategory.CategoryName;
//         existingCategory.Active = productCategory.Active;
//         existingCategory.Description = productCategory.Description;

//         _repository.Update(existingCategory);
//         return Ok();
//     }

//     [HttpGet]
//     public IActionResult GetProductCategories()
//     {
//         var categories = _repository.List();
//         return Ok(categories);
//     }

//     [HttpGet("{id}")]
//     public IActionResult GetProductCategoryById(int id)
//     {
//         var category = _repository.GetById(id);
//         if (category == null)
//             return NotFound();

//         return Ok(category);
//     }

//     [HttpDelete("{id}")]
//     public IActionResult DeleteProductCategory(int id)
//     {
//         var category = _repository.GetById(id);
//         if (category == null)
//             return NotFound();

//         _repository.Delete(category);
//         return Ok();
//     }
// }

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryController(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    // Implement API methods for Create, Update, List, Search, and Delete operations for ProductCategory
}
