using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD_Web_API_Stored_Procedure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define a method for each stored procedure
        public virtual void CreateProduct(string productName, decimal price)
        {
            // Call the CreateProduct stored procedure using FromSqlRaw
            Database.ExecuteSqlRaw("EXEC CreateProduct @ProductName, @Price",
                new SqlParameter("@ProductName", productName),
                new SqlParameter("@Price", price));
        }

        // Define methods for other stored procedures (ReadProduct, UpdateProduct, DeleteProduct)
    }

}