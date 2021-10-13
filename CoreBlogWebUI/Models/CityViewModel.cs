using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogWebUI.Models
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}