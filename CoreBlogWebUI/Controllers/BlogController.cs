using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;

        }

        public IActionResult Index()
        {
            var result = _blogService.GetBlogListDto();
            return View(result);
        }

        public IActionResult BlogDetails(int id)
        {

            ViewBag.comment = id;
            var result = _blogService.GetBlog(id);
            return View(result);
        }

        public IActionResult GetBlogWriterId()
        {
            var result = _blogService.GetByWriterId(2);
            return View(result);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            BlogValidation blogValidation = new BlogValidation();
            ValidationResult validationResult = blogValidation.Validate(blog);

            if (validationResult.IsValid)
            {
                _blogService.Add(blog);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var result = _blogService.GetBlog(id);

            List<SelectListItem> categoryListItems = (from x in _categoryService.GetAll()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CategoryName,
                                                          Value = x.CategoryId.ToString()
                                                      }).ToList();
            ViewBag.categoryList = categoryListItems;
            return View(result);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            _blogService.Update(blog);
            return RedirectToAction("GetBlogWriterId");
        }



        public IActionResult DeleteBlog(int id)
        {
            var result = _blogService.GetBlog(id);
            _blogService.Delete(result);
            return RedirectToAction("GetBlogWriterId");
        }

        








        
    }
}
