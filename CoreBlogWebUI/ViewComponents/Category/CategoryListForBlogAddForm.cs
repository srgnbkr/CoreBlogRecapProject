using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.ViewComponents.Category
{
    public class CategoryListForBlogAddForm : ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryListForBlogAddForm(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _categoryService.GetAll();
            return View(result);
        }
    }
}
