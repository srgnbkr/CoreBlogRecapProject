using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        INewsLetterService _newsLetterService;

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail([FromForm]NewsLetter newsLetter)
        {
            _newsLetterService.AddNewsLetter(newsLetter);
            return PartialView();
        }
    }
}
