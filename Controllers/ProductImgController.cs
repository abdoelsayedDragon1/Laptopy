using Laptopy.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImgController : ControllerBase
    {
        private readonly IProductImagesRepository productImagesRepository;

        public ProductImgController(IProductImagesRepository productImagesRepository)
        {
            this.productImagesRepository = productImagesRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var productImg= productImagesRepository.Get().ToList();
            return Ok(productImg);
        }
    }
}
