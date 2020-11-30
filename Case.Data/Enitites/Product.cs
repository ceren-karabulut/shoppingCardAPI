using System;
using System.Collections.Generic;
using System.Text;

namespace Case.Data.Enitites
{
   public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int StockAmount { get; set; }

        public decimal Price { get; set; }
    }
}
