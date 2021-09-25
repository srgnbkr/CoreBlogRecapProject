using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {

        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            blog.BlogStatus = false;
            _blogDal.Delete(blog);
           
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public Blog GetBlog(int id)
        {
            return _blogDal.Get(x => x.BlogId == id);
        }

        public List<Blog> GetBlogListDto()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog GetCategory(int id)
        {
            return _blogDal.Get(x =>x.CategoryId == id);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
