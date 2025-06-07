using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public String Name { get; set; } = string.Empty;
        public String Description { get; set; } = string.Empty;

    }
}
