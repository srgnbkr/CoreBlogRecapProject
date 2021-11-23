using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class WriterBlogDto :IDto
    {
        public int BlogId { get; set; }
        public int WriterId { get; set; }
        public string BlogTitle { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public string CategoryName { get; set; }
        public string BlogThumbnailImage { get; set; }
        public bool BlogStatus { get; set; }
        public string BlogImage { get; set; }





    }
}
