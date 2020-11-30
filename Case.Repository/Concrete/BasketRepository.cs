using Case.Data.Context;
using Case.Data.Enitites;
using Case.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Case.Repository.Concrete
{
    public class BasketRepository : BaseRepository<Product>, IBasketRepository
    {
        private readonly CaseContext _context;
        public BasketRepository(CaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> ControlStock(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product.StockAmount == 0)
            {
                return -1;
            }
            else
            {

                return 0;
            }
        }
    }
}
