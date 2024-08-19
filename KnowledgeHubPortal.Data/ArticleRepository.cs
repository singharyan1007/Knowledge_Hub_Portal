using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.EntityFrameworkCore;

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

       public  void Approve(List<int> ids)
        {
            //but this method will call the db again and again for all the records. Sends update statements many times
            foreach (int id in ids) 
            {
                var articlesToApprove = db.Articles.Find(id);
                if (articlesToApprove != null)
                {
                    articlesToApprove.IsApproved = true;
                }
            }
            db.SaveChanges();
        }

        public List<Article> GetArticlesForApprove(int cid)
        {
            
            if (cid == 0)
                return db.Articles.Include(c=>c.Category).Where(a => !a.IsApproved).ToList();
            else
                return db.Articles.Include(c=>c.Category).Where(a => !a.IsApproved && a.CateoryId == cid).ToList();
        }

       public List<Article> GetArticlesForBrowse(int cid)
        {
            if(cid==0)
                return db.Articles.Where(a => a.IsApproved).ToList();
            else
                return db.Articles.Where(a => a.IsApproved && a.CateoryId == cid).ToList();
        }

       public void Reject(List<int> ids)
        {
            foreach (int id in ids)
            {
                var articlesToApprove = db.Articles.Find(id);
                if (articlesToApprove != null)
                {
                    db.Articles.Remove(articlesToApprove);
                }
            }
            db.SaveChanges();
        }
    }
}
