using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto;
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
            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Now;
            blog.WriterId = 2;
           
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            
            
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
            return _blogDal.GetListWithCategory().Where(x => x.BlogStatus == true).ToList();
        }

        public List<WriterBlogDto> GetByWriterId(int id)
        {
            return _blogDal.GetBlogDetails(x => x.WriterId == id).Where(x => x.BlogStatus == true).ToList();
        }

        public Blog GetCategory(int id)
        {
            return _blogDal.Get(x =>x.CategoryId == id);
        }


        public void Update(Blog blog)
        {
            blog.WriterId = 2;
            blog.BlogStatus = true;
            
            _blogDal.Update(blog);
        }
    }
}
