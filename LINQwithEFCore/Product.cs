using System;
using System.Collections.Generic;

namespace LINQwithEFCore
{
    public partial class Product
    {
        public Product()
        {
            RequestLines = new HashSet<RequestLine>();
        }

        public int Id { get; set; }
        public string PartNbr { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Unit { get; set; } = null!;
        public string? PhotoPath { get; set; }
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; } = null!;
        public virtual ICollection<RequestLine> RequestLines { get; set; }
    }
}
