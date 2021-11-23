using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IGenericRepository<Blog>
    {
        List<Blog> GetListWithCategory();
        List<WriterBlogDto> GetBlogDetails(Expression<Func<WriterBlogDto, bool>> filter = null);
    }
}
