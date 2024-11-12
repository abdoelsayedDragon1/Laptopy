using AutoMapper;
using Laptopy.DTOs;
using Laptopy.Models;
using Laptopy.Profiles;
using Laptopy.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository  productRepository, IMapper mapper  )
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
         var products = productRepository.Get().ToList();
            if( products.Any())
            {
                //List<ProductCategoryDTO> categories = new List<ProductCategoryDTO>();
                //foreach( var item in products ) 
                //{

                //    categories.Add(mapper.Map<ProductCategoryDTO>(item));


                //}

                return Ok(products);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int productId)
        {
            var product = productRepository.GetOne(expression: e => e.Id == productId);
            if (product != null)
            {

               return Ok(product);
            }
            return NotFound();
        }


    }
}
