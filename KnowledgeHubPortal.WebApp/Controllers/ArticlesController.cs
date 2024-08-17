using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using KnowledgeHubPortal.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository ArticleRepository;
        private readonly ICategoryRepository categoryRepository;

        public ArticlesController(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            this.ArticleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var articles = ArticleRepository.GetAll();
            return View(articles);
        }

        public IActionResult Add()
        {
            List<Category> categories = categoryRepository.GetAll();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult Save(Article article)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the categories in case of a validation error
                List<Category> categories = categoryRepository.GetAll();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

                return View("Add", article); // Use "Add" to render the Add view again
            }

            ArticleRepository.Create(article);
            return RedirectToAction("Index");
        }
    }

}
