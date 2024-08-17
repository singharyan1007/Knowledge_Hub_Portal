
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnowledgeHubPortal.WebApp.Models
{
    public class ArticleViewModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int SelectedCategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
