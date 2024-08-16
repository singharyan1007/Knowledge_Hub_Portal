using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repository
{
    public interface IArticleRepository
    {
        void Create(Article article);
        void Update(Article article);

        List<Article> GetAll();
        Article GetById(int id);

        void Delete(int id);
    }
}
