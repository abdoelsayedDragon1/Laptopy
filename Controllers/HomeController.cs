using Laptopy.Models;
using Laptopy.Repository;
using Laptopy.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var newArrivals = productRepository.Get(expression: p => p.IsNewArrival);
            var trendingProducts = productRepository.Get(expression: p => p.IsTrendingLaptops);
            var specialProducts = productRepository.Get(expression: p => p.IsSpecialProducts);

            var result = new
            {
                NewArrivals = newArrivals,
                TrendingProducts = trendingProducts,
                SpecialProducts = specialProducts
            };

            return Ok(result);
        }



        [HttpGet("Search")]
        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return BadRequest("Search Term Cannot be Empty");
            }
            searchTerm = searchTerm.ToLower();

            var products = productRepository.Get().Where(p => p.Name.ToLower().Contains(searchTerm) ||(p.Category != null && p.Category.Name.ToLower().Contains(searchTerm))).ToList();

            if (!products.Any())
            {
                return NotFound("No Products Found Matching The Search Term");
            }

            return Ok(products);
        }

        [HttpGet("Search filter")]
        public IActionResult Search(decimal? minPrice, decimal? maxPrice, string model, decimal? Rating)
        {
            var query = productRepository.Get().AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(p => p.Model.ToLower().Contains(model.ToLower()));
            }

            if (Rating.HasValue)
            {
                query = query.Where(p => p.Rating >= Rating.Value);
            }

            var products = query.ToList();

            if (!products.Any())
            {
                return NotFound("No Products Found Matching The Search Criteria");
            }

            return Ok(products);
        }




    }
}
