using AutoMapper;
using Laptopy.DTOs;
using Laptopy.Models;
using Laptopy.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(ApplicationUserDTO userDTO)
        {
            if (roleManager.Roles.IsNullOrEmpty())
            {
                await roleManager.CreateAsync(new(SD.adminRole));
                await roleManager.CreateAsync(new(SD.customerRole));
            }
            if (ModelState.IsValid)
            {
                //ApplicationUser user = new()
                //{
                //    UserName = $"{userDTO.FristName}_{userDTO.LastName}",
                //    Email = userDTO.Email,

                //};

              var user = mapper.Map<ApplicationUser>(userDTO);
                var result = await userManager.CreateAsync(user, userDTO.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, SD.customerRole);
                    await signInManager.SignInAsync(user, false);
                    return Ok();
                }
                return BadRequest(result.Errors);

            }
            return BadRequest(userDTO);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTo loginDTo)
        {
            var user = await userManager.FindByEmailAsync(loginDTo.EmailAddress);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, loginDTo.Password);
                if (result)
                {
                    await signInManager.SignInAsync(user, false);
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There are errors");
                }
            }
            return NotFound();
        } 
        
        
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
           await signInManager.SignOutAsync();
            return Ok();
        }


    }
}
