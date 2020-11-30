using Case.Service.Abstract;
using Case.Service.Request;
using Case.Service.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Tum urunleri listeler.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ProductResponse>> GetAll()
        {
            return await _service.GetProducts();
        }

        /// <summary>
        /// Db ilk basta bos gelecektir.Lutfen bir urun ekleyiniz.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequest request)
        {
            var affectedRowCount = await _service.AddProduct(request);
            if (affectedRowCount > 0)
            {
                return Ok(request);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
