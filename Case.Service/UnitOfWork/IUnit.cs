using Case.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Case.Service.UnitOfWork
{
   public interface IUnit
    {
        IProductRepository Product { get; set; }

        IBasketRepository Basket { get; set; }
    }
}
