using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryRepository efCategoryRepository;

        public CategoryManager(EfCategoryRepository efCategoryRepository)
        {
            this.efCategoryRepository = efCategoryRepository;
        }

        public void Add(Category category)
        {
            efCategoryRepository.Add(category);
        }

        public void Delete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public List<Category> GetAll()
        {
            return efCategoryRepository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return efCategoryRepository.GetById(id);
        }

        public void Update(Category category)
        {
            efCategoryRepository.Update(category);
        }
    }
}
