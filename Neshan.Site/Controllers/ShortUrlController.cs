using Library.Core.Enums;
using Library.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Neshan.Application.IServices;
using Neshan.Domain.DTOs.Common;
using Neshan.Domain.DTOs.ShortURL;
using Neshan.Domain.DTOs.User;
using Neshan.Domain.Entities;
using Neshan.Site.Managers;

namespace Neshan.Site.Controllers
{
    [AuthenticationLogin]
    public class ShortUrlController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeController> _logger;
        private readonly IShortUrlService _shortUrlService;

        public ShortUrlController(ILogger<HomeController> logger, IShortUrlService shortUrlService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _shortUrlService = shortUrlService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> List(ListFilterDTO filter)
        {
            IList<ShortUrlDTO> retval = new List<ShortUrlDTO>();
            filter.userID = HTTPContextManager.getUserID(_httpContextAccessor.HttpContext);

            var result = await _shortUrlService.GetList(filter);
            retval = result.Item2.Items;

            return View(retval);
        }

        [HttpGet]
        public async Task<IActionResult> GetLink()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetLink(ShortUrlDTO model)
        {
            Guid userID = HTTPContextManager.getUserID(_httpContextAccessor.HttpContext);

            string key = model.ShortURL.LocalPath.Replace("/", "");
            var result = await _shortUrlService.GetOriginalUrl(key, userID);

            ViewBag.SharedResult = result.Item1;
            return View(result.Item2);
        }


        [HttpGet("/{key}")]
        public async Task<IActionResult> GetUrl(string key)
        {
            Guid userID = HTTPContextManager.getUserID(_httpContextAccessor.HttpContext);

            var result = await _shortUrlService.GetOriginalUrl(key, userID);

            ////can redirect
            //return Redirect(result.Item2);

            ViewBag.SharedResult = result.Item1;
            return View(result.Item2);
        }

        [HttpGet]
        public async Task<IActionResult> AddUrl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUrl(ShortUrlDTO model)
        {
            SharedEnums.SharedResult retval = SharedEnums.SharedResult.None;

            //validation


            //generate
            ShortUrl url = await _shortUrlService.GenerateShortUrl(model.OriginalURL);

            //send to service
            url.UserID = HTTPContextManager.getUserID(_httpContextAccessor.HttpContext);
            retval = await _shortUrlService.AddUrl(url);

            if (retval == SharedEnums.SharedResult.Successful)
            {
                return RedirectToAction("List");
            }

            ViewBag.SharedResult = retval;
            return View();
        }

        
    }
}