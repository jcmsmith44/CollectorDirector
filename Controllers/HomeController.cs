using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CollectorDirector.Models;
using CollectorDirector.ViewModels;
using CollectorDirector.Data;

namespace CollectorDirector.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CollectionDbContext context;

        public HomeController(ILogger<HomeController> logger, CollectionDbContext dbContext)
        {
            context = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Collection> collections = context.Collections.ToList();

            return View(collections);
        }

        public IActionResult CreateCollection()
        {
            CreateCollectionViewModel createCollectionViewModel = new CreateCollectionViewModel();

            return View(createCollectionViewModel);
        }

        [HttpPost]
        public IActionResult CreateCollection(CreateCollectionViewModel createCollectionViewModel)
        {
            if (ModelState.IsValid)
            {
                Collection newCollection = new Collection
                {
                    CollectionName = createCollectionViewModel.CollectionName
                };

                context.Collections.Add(newCollection);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "");
        }

        public IActionResult EditCollection(int id)
        {
            Collection editCollection = context.Collections.Single(c => c.ID == id);

            CreateCollectionViewModel editCollectionViewModel = new CreateCollectionViewModel();

            editCollectionViewModel.CollectionName = editCollection.CollectionName;

            return View(editCollectionViewModel);
        }

        [HttpPost]
        public IActionResult EditCollection(CreateCollectionViewModel editCollectionViewModel, int id)
        {
            Collection editCollection = context.Collections.Single(c => c.ID == id);

            if (ModelState.IsValid)
            {
                editCollection.CollectionName = editCollectionViewModel.CollectionName; 
            }

            context.SaveChanges();

            return RedirectToAction("Index", "");
        }


        public IActionResult RemoveCollection(int id)
        {
            Collection theCollection = context.Collections.Single(c => c.ID == id);

            context.Collections.Remove(theCollection);
            context.SaveChanges();

            return RedirectToAction("Index", "");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
