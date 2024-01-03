using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly AppDbContext _context;

    public ProductCategoryRepository(AppContext context)
    {
        _context = context;
    }

    public void Create(ProductCategory productCategory)
    {
        try
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            // Handle or log the exception
            Console.WriteLine($"Error saving changes: {ex.Message}");
            throw; // Re-throw the exception to propagate it up the call stack
        }
    }

    public void Update(ProductCategory productCategory)
    {
        _context.ProductCategories.Update(productCategory);
        _context.SaveChanges();
    }

    public List<ProductCategory> List()
    {
        return _context.ProductCategories.ToList();
    }

    public ProductCategory GetById(int id)
    {
        return _context.ProductCategories.Find(id);
    }

    public void Delete(ProductCategory productCategory)
    {
        _context.ProductCategories.Remove(productCategory);
        _context.SaveChanges();
    }
}
