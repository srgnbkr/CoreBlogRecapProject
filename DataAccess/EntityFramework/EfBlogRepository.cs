using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBlogRepository : EfGenericRepositoryBase<Blog, DataDbContext>, IBlogDal
    {
        public List<WriterBlogDto> GetBlogDetails(Expression<Func<WriterBlogDto, bool>> filter = null)
        {
            using (var context = new DataDbContext())
            {
                var result = from bg in context.Blogs
                             join wr in context.Writers
                             on bg.WriterId equals wr.WriterId
                             join cr in context.Categories
                             on bg.CategoryId equals cr.CategoryId
                             select new WriterBlogDto
                             {
                                 BlogId = bg.BlogId,
                                 WriterId = wr.WriterId,
                                 CategoryName = cr.CategoryName,
                                 BlogCreateDate = bg.BlogCreateDate,
                                 BlogTitle = bg.BlogTitle,
                                 BlogStatus = bg.BlogStatus,
                                 BlogThumbnailImage = bg.BlogThumbnailImage,
                                 BlogImage = bg.BlogImage,

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<Blog> GetListWithCategory()
        {
            using(var context = new DataDbContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}
