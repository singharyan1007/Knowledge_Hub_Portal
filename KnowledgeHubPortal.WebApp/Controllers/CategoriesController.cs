using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        //  .../categories/index

        ICategoryRepository CategoryRepository = null;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            //fetch the categories list from the datalayer
            //send the list of categories to view
            //Contact the datalayer only through the Repository
            //No individual context should be created
            
            
            //Create an object for the repository
            //ICategoryRepository categoryRepository = new CategoryRepository();// BAD-DIP

            //Send the list of categories to view
            List<Category> Categories=CategoryRepository.GetAll();
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
            //Validate
            if (!ModelState.IsValid)
            {
                return View("Add");
            }


            //Receive the data from the UI
            //ICategoryRepository categoryRepository = new CategoryRepository();

            CategoryRepository.Create(category);

            //Redirect to home of category
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            //get the category details using GetById
            //ICategoryRepository categoryRepository = new CategoryRepository();
            Category category = CategoryRepository.GetById(id);
            return View(category);
        }

        public IActionResult Update(Category category) 
        {
            //Even to update we need the Category ID or the primary key
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            //ICategoryRepository categoryRepository = new CategoryRepository();
            CategoryRepository.Update(category);
            return RedirectToAction("Index");

        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //ICategoryRepository repo = new CategoryRepository();
            CategoryRepository.Delete(id);
            CategoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
