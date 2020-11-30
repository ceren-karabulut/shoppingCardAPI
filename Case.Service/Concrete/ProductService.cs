using Case.Data.Enitites;
using Case.Service.Abstract;
using Case.Service.Request;
using Case.Service.Response;
using Case.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnit _unit;
        public ProductService(IUnit unit)
        {
            _unit = unit;
        }

        public async Task<int> AddProduct(ProductCreateRequest request)
        {
            Product product = new Product()
            {
                Name = request.Name,
                Category = request.Category,
                StockAmount = request.StockAmount,
                Price = request.Price
            };
            return await _unit.Product.Add(product);
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            var product = await _unit.Product.GetById(id);
            if (product==null)
            {
                return null;
            }

            return  new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                StockAmount = product.StockAmount,
                Price = product.Price
            };
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await _unit.Product.GetAll();
            var responses = products.Select(x => new ProductResponse
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category,
                StockAmount = x.StockAmount,
                Price = x.Price
            }).ToList();

            return responses;
        }
    }
}
