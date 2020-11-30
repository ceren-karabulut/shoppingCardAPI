using Case.Data.Context;
using Case.Data.Enitites;
using Case.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Case.Repository.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CaseContext context) : base(context)
        {
        }
    }
}
