using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            // Eager Loading -> Veriyi çekerken ilişkisiyle çekmek
            // Lazy loading -> İhtiyaç olduğunda çekme
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
