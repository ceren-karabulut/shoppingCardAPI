using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Case.Service.Abstract
{
    public interface IBasketService
    {
        Task<int> ReduceStock(int id);
    }
}
