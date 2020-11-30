using System;
using System.Collections.Generic;
using System.Text;

namespace Case.Service.Request
{
   public class ProductCreateRequest
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int StockAmount { get; set; }

        public decimal Price { get; set; }
    }
}
