using Laptopy.Models;
using Laptopy.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsontroller : ControllerBase
    {
        private readonly IContacUsRepository contacUsRepository;

        public ContactUsontroller(IContacUsRepository contacUsRepository)
        {
            this.contacUsRepository = contacUsRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var contact= contacUsRepository.Get().ToList();
            return Ok(contact);
        }

        [HttpPost("CreateContactUs")]
        public IActionResult CreateContactUs([FromBody] ContactUs contactUs)
        {
            if (contactUs == null)
            {
                return BadRequest("Invalid Contact Us Data");
            }

            contacUsRepository.Create(contactUs);
            contacUsRepository.commit();

            return Ok("Contact Us Message Has Been Created Successfully");
        }
    }
}
