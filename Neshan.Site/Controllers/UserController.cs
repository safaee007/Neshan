using Microsoft.AspNetCore.Mvc;
using Neshan.Application.IServices;
using Neshan.Domain.DTOs.User;
using Neshan.Domain.Entities;
using Neshan.Site.Managers;
using static Library.Core.Enums.SharedEnums;

namespace Neshan.Site.Controllers
{
    [Logined]
    public class UserController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<HomeController> logger, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            //validation

            //send to service
            var result = await _userService.Login(model);

            if (result.Item1 == SharedResult.Successful)
            {
                //set session
                Managers.SessionManager.SetSession(_httpContextAccessor.HttpContext, "fakeToken", result.Item2.UserID);

                return RedirectToAction("list", "ShortUrl");
            }
            
            ViewBag.SharedResult = result.Item1;

            return View(model);
        }

        [HttpPost]
        [UserValidation]
        public async Task<IActionResult> Register(UserDTO model)
        {

            // send to service
            var result = await _userService.Register(model);


            ViewBag.SharedResult = result;

            return View(model);
        }
    }
}