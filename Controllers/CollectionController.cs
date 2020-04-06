using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectorDirector.Data;
using CollectorDirector.Models;
using CollectorDirector.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollectorDirector.Controllers
{
    public class CollectionController : Controller
    {
        private CollectionDbContext context;

        public CollectionController(CollectionDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult DisplayCollection(int id)
        {
            List<CollectionItem> collectionItems = context.CollectionItems.Where(ci => ci.CollectionID == id).ToList();
            ViewData["CollectionID"] = id;

            return View(collectionItems);
        }

        public IActionResult AddCollectionItem(int thisID)
        {
            AddCollectionItemViewModel addCollectionItemViewModel = new AddCollectionItemViewModel();
            Collection thisCollection = context.Collections.Single(c => c.ID == thisID);
            ViewData["CollectionID"] = thisCollection.ID;

            return View(addCollectionItemViewModel);
        }

        [HttpPost]
        public IActionResult AddCollectionItem(AddCollectionItemViewModel addCollectionItemViewModel, int collectionID)
        {
            if (0 == 0)
            {
                CollectionItem newItem = new CollectionItem
                {
                    ItemName = addCollectionItemViewModel.ItemName,
                    IsOwned = addCollectionItemViewModel.IsOwned,
                    Rarity = addCollectionItemViewModel.Rarity,
                    UserNote = addCollectionItemViewModel.UserNote,
                    CollectionID = addCollectionItemViewModel.CollectionID,
                };

                context.CollectionItems.Add(newItem);
                context.SaveChanges();
            }
            
        return RedirectToAction("DisplayCollection", "Collection", new {id = addCollectionItemViewModel.CollectionID});
    }

        public IActionResult RemoveCollectionItem(int id)
        {
            CollectionItem theCollectionItem = context.CollectionItems.Single(ci => ci.ID == id);

            context.CollectionItems.Remove(theCollectionItem);
            context.SaveChanges();

            return RedirectToAction("DisplayCollection", "Collection");
        }

        public IActionResult AddCollectionCategory()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();

            return View(addCategoryViewModel);
        }
    }
}