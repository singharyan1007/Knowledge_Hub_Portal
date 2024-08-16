using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;

namespace KnowledgeHubPortal.Data
{
    public class ArticleRepository : IArticleRepository
    {

        private KHPDbContext db = new KHPDbContext();
        public void Create(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Articles.Remove(db.Articles.Find(id));
            db.SaveChanges();
        }

        public List<Article> GetAll()
        {
            return db.Articles.ToList();
        }

        public Article GetById(int id)
        {
            return db.Articles.Find(id);
        }

        public void Update(Article article)
        {
            db.Articles.Update(article);
            db.SaveChanges();
        }

       
    }
}
