using Case.Service.Abstract;
using Case.Service.Request;
using Case.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Case.Service.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IUnit _unit;
        public BasketService(IUnit unit)
        {
            _unit = unit;
        }

        public async Task<int> ReduceStock(int id)
        {   
            
            var entity = await _unit.Basket.GetById(id);
            var stockState = await _unit.Basket.ControlStock(id);

            
            if (stockState== -1)
            {
                return -1; 
            }
            else
            {
                entity.StockAmount--;
                
               return await _unit.Basket.SaveChanges();
            }
            
        }
    }
}
