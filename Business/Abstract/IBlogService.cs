using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        Blog GetCategory(int id);
        Blog GetBlog(int id);
        List<Blog> GetAll();
        List<Blog> GetBlogListDto();
        List<Blog> GetByWriterId(int id);
        
    }
}
