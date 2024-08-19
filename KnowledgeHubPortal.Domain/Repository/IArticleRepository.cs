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
        void Approve(List<int> ids);
        void Reject(List<int> ids);
        List<Article> GetArticlesForBrowse(int cid=0);//default value is 0
        List<Article> GetArticlesForApprove(int cid=0);//default value is 0

    }
}
