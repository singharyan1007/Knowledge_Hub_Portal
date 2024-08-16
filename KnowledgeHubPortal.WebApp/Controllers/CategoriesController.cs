using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        //  .../categories/index
        public IActionResult Index()
        {
            //fetch the categories list from the datalayer
            //send the list of categories to view
            //Contact the datalayer only through the Repository
            //No individual context should be created
            
            
            //Create an object for the repository
            ICategoryRepository categoryRepository = new CategoryRepository();// BAD-DIP

            //Send the list of categories to view
            List<Category> Categories=categoryRepository.GetAll();
            return View(Categories); //pass it the the View
        }


        //Add the "Add Category" action method
        public IActionResult Add() 
        {
            //On clicking it - Display a new UI to collect the data
            return View();
        }

        public IActionResult Save(Category category)
        {
            //Receive the data from the UI
            ICategoryRepository categoryRepository = new CategoryRepository();

            categoryRepository.Create(category);

            //Redirect to home of category
            return RedirectToAction("Index");

        }
    }
}
