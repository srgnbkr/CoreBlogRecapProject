using Business.Abstract;
using Business.ValidationRules;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IWriterService _writerService;

        public RegisterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer)
        {
            WriterValidation writerValidatoin = new WriterValidation();
            ValidationResult results = writerValidatoin.Validate(writer);
            if (results.IsValid) //Sonra bunları genel try catch içine alıp süreki if-else olarak kullanmayacağım şimdilik böyle :)
            {
                _writerService.Register(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
