﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Web_API_Stored_Procedure
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(string productName, decimal price)
        {
            // Call the Products stored procedure using FromSqlRaw
            _context.Database.ExecuteSqlRaw("EXEC Products @ProductName, @Price",
                new SqlParameter("@ProductName", productName),
                new SqlParameter("@Price", price));
        }
        public Product ReadProduct(int productId)
        {
            // Call the ReadProduct stored procedure using _context.Database.FromSqlRaw or another suitable method
            return _context.Set<Product>().FromSqlRaw("EXEC ReadProduct @ProductId", new SqlParameter("@ProductId", productId)).AsEnumerable().FirstOrDefault();
            _context.Database.ExecuteSqlRaw("EXEC ReadProduct @ProductId", new SqlParameter("@ProductId", productId));
            return _context.Set<Product>().Find(productId);

        }


        public void UpdateProduct(Product product)
        {
            // Call the UpdateProduct stored procedure using _context.Database.ExecuteSqlRaw or another suitable method
        }

        public void DeleteProduct(int productId)
        {
            // Call the DeleteProduct stored procedure using _context.Database.ExecuteSqlRaw or another suitable method
        }
    }
}