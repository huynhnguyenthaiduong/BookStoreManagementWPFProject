using System;
using System.Collections.Generic;

namespace BookStoreManagementBO
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime ImportDate { get; set; }
        public string OriginSource { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool? IsAvailable { get; set; }
        public int CategoryId { get; set; }

        public virtual BookCategory Category { get; set; } = null!;
    }
}
