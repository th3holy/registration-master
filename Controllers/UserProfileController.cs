using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using registration.models;

namespace registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Authorize]
        // GET : api/UserProfile
        public async Task<object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.fullName,
                user.Email,
                user.UserName,

            };
        } 


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "hola admin ";
        }


        [HttpGet]
        [Authorize(Roles = "Productor")]
        [Route("ForProductor")]
        public string GetForProductor()
        {
            return "hola Productor ";
        }

        [HttpGet]
        [Authorize(Roles = "Productor,Admin")]
        [Route("ForProductorOrAdmin")]
        public string GetForProductorOrAdmin()
        {
            return "hola admin y Productor ";
        }
    }
}
