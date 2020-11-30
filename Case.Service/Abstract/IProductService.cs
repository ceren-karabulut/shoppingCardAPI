using Case.Data.Enitites;
using Case.Service.Request;
using Case.Service.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Case.Service.Abstract
{
   public interface IProductService
    {
        Task<int> AddProduct(ProductCreateRequest request);

        Task<ProductResponse> GetProductById(int id);

        Task<List<ProductResponse>> GetProducts();
    }
}
