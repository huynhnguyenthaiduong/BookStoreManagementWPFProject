using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementBO.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime ImportDate { get; set; }
        public string OriginSource { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool? IsAvailable { get; set; }
        public string Category { get; set; }
    }
}
