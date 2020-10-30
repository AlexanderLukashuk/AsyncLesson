using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncLesson.Domain
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
