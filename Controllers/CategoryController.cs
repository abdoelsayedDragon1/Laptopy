using Laptopy.Repository.IRepository;
using Laptopy.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =$"{SD.adminRole}")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
          var Category = categoryRepository.Get().ToList();
            return Ok(Category);
        }
    }
}
