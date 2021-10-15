using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.Controllers
{
    public class AboutController : Controller
    {

        IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var result = _aboutService.GetAll();
            return View(result);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
