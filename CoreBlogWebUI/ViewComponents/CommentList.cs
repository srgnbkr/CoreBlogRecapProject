using CoreBlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    Username = "Sergen"
                },
                new UserComment
                {
                    Id=2,
                    Username ="Ece"

                },
                new UserComment
                {
                    Id = 3,
                    Username = "Burcu"
                }
            };
            return View(result);
        }
    }
}
