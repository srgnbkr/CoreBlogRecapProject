using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBlogRepository : EfGenericRepositoryBase<Blog, DataDbContext>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using(var context = new DataDbContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}
