using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class ArticlesController : Controller
    {
        //.../Articles/Index

        IArticleRepository ArticleRepository = null;

        public ArticlesController(IArticleRepository articleRepository)
        {
            ArticleRepository=articleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add() 
        {
            return View();
        }

        public IActionResult Save(Article article) 
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }

            ArticleRepository.Create(article);
            return RedirectToAction("Index");

        }
    }
}
