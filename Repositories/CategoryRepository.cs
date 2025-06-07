using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using Repositories.Data;
using Repositories.Entity;

namespace Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository() : base()
        {
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Category.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
