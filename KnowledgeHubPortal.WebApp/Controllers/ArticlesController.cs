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

        public IActionResult Index(int cid=0)
        {
            //browse articles
            var articlesToBrowse = ArticleRepository.GetArticlesForBrowse(cid);
            //var categories = categoryRepository.GetAll();

            var Categories = from cat in categoryRepository.GetAll()
                             select new SelectListItem { Text = cat.CategoryName, Value = cat.CateoryId.ToString() };

            ViewBag.Categories=Categories;
           
            return View(articlesToBrowse);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = from cat in categoryRepository.GetAll()
                             select new SelectListItem { Text = cat.CategoryName, Value = cat.CateoryId.ToString() };

            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Article article)
        {
            if (!ModelState.IsValid)
            {

                return View(); 
            }
            article.DateSubmitted=DateTime.Now;
            article.IsApproved = false;
            if (User.Identity.IsAuthenticated)
            {
                article.SubmittedBy = User.Identity.Name;
            }
            else
            {
                article.SubmittedBy = "Unknown";
            }

            ArticleRepository.Create(article);
            //Before we send the article, a notification needs to be sent
            //So we use TempData -> read once

            TempData["Message"] = $"Article {article.Title} has been sent to the admin for approval";



            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Approve(int cid = 0)
        {
            var articles = ArticleRepository.GetArticlesForApprove();
            return View(articles);
        }

        [HttpPost]
        public IActionResult Approve()
        {
            return View();
        }
    }

}
