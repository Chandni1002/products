// // ProductCategoryRepository.cs
// using System;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;

// namespace ApplicationDbContext
// {
//     public class ProductCategoryRepository : IProductCategoryRepository
//     {
//         private readonly ApplicationDbContext _context;

//         public ProductCategoryRepository(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         public void Create(ProductCategory productCategory)
//         {
//             try
//             {
//                 _context.ProductCategories.Add(productCategory);
//                 _context.SaveChanges();
//             }
//             catch (DbUpdateException ex)
//             {
//                 Console.WriteLine($"Error saving changes: {ex.Message}");
//                 throw; // Re-throw the exception to propagate it up the call stack
//             }
//         }

//         public void Update(ProductCategory productCategory)
//         {
//             _context.ProductCategories.Update(productCategory);
//             _context.SaveChanges();
//         }

//         public List<ProductCategory> List()
//         {
//             return _context.ProductCategories.ToList();
//         }

//         public ProductCategory GetById(int id)
//         {
//             return _context.ProductCategories.Find(id);
//         }

//         public void Delete(ProductCategory productCategory)
//         {
//             _context.ProductCategories.Remove(productCategory);
//             _context.SaveChanges();
//         }
//     }
// }
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApplicationDbContext
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
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
}
