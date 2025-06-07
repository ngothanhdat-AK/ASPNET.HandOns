using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ProductResponse
    {
        public class ProductResponseDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public int CategoryId { get; set; }
            public CategoryDto Category { get; set; }
        }

        public class CategoryDto
        {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
