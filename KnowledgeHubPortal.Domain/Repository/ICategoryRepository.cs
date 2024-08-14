using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repository
{
    public  interface ICategoryRepository
    {
        void Create(Category category);
        void Update(Category category);

        List<Category> GetAll();
        Category GetById(int id);
    }
}
