using Case.Service.Abstract;
using Case.Service.Concrete;
using Case.Service.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productServie;
        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productServie = productService;
        }

        /// <summary>
        /// sepete eklemek istediğiniz ürünün id 'sini giriniz.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost("{productId}")]
        public async Task<IActionResult> Add([FromRoute] int productId)
        {
            var product = await _productServie.GetProductById(productId);
            if (product==null)
            {
                return BadRequest("Girdiginiz Id'ye ait bir urun bulunamadi!");
            }

            var stock = await _basketService.ReduceStock(productId);
            if (stock==-1)
            {
                return BadRequest("Urun stokta yok!");
            }
            else
            {
                var value = JsonConvert.SerializeObject(product);
               HttpContext.Session.SetString("basket", Encoding.UTF8.GetBytes(value).ToString());
                
                return Ok("Urun sepete eklendi");

            }
        }
        
        /// <summary>
        /// Tutulan session value'yu byte formatında doner.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSession4Redis()
        {

            if (HttpContext.Session.TryGetValue("basket", out byte[] value))
            {
             var redisValue = Encoding.UTF8.GetString(value);
                return Ok(redisValue);
            }
            else
            {
                return BadRequest("session bilgisine ulasilamadi.");
            }
        }

    }
}
