using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncLesson.Domain
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
