using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;

namespace KnowledgeHubPortal.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private KHPDbContext db = new KHPDbContext(); //DIP
        //WE have to create a very tight coupling between Repository and Contxt
        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
           return db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return db.Categories.Find(id);
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }
    }
}
