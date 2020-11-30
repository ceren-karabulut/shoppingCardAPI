using Case.Data.Enitites;
using Case.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Case.Repository.Abstract
{
    public interface IBasketRepository : IBaseRepository<Product>
    {
        Task<int> ControlStock(int id);
    }
}
