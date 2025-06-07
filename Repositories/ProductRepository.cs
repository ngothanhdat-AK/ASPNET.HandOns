using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using Repositories.Entity;

namespace Repositories
{
    public class ProductRepository: GenericRepository<Product>
    {
        public ProductRepository()
        {

        }
        public async Task<Product?> GetByIdWithCategoryAsync(int id)
        {
            return await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
