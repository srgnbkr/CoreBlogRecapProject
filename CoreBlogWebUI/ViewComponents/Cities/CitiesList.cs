using CoreBlogWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.ViewComponents.Cities
{
    public class CitiesList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cityValues = new List<CityViewModel>
            {
                new CityViewModel
                {
                    CityId=1,
                    CityName="Aydın"
                },
                new CityViewModel
                {
                    CityId=2,
                    CityName="İzmir"
                },
                new CityViewModel
                {
                    CityId=3,
                    CityName="Denizli"
                },new CityViewModel
                {
                    CityId=4,
                    CityName="Ankara"
                }
            };
            List<SelectListItem> valuecity = (from x in cityValues
                                              select new SelectListItem
                                              {
                                                  Text = x.CityName,
                                                  Value = x.CityId.ToString()
                                              }).ToList();
            ViewBag.cities = valuecity;
            return View();
        }
    }
}
