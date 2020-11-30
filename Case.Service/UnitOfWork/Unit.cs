using Case.Data.Context;
using Case.Repository.Abstract;
using Case.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Case.Service.UnitOfWork
{
    public class Unit : IUnit
    {
        public CaseContext _context;
        public Unit(CaseContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
            Basket = new BasketRepository(_context);
        }

        public IProductRepository Product { get; set; }
        public IBasketRepository Basket { get ; set; }
    }
}
