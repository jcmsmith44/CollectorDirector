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

        public IActionResult DisplayCollection(int id, string search)
        {
            List<CollectionItem> collectionItems = context.CollectionItems.Where(ci => ci.CollectionID == id).ToList();
   
                if (!String.IsNullOrEmpty(search))
                {
                collectionItems = collectionItems.Where(ci => ci.ItemName.Contains(search)).ToList();
                }
            
            ViewData["CollectionID"] = id;
            ViewData["CollectionName"] = context.Collections.Single(c => c.ID == id).CollectionName;
            ViewData["Search"] = search;

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
            if (ModelState.IsValid)
            {
                CollectionItem newItem = new CollectionItem
                {
                    ItemName = addCollectionItemViewModel.ItemName,
                    IsOwned = addCollectionItemViewModel.IsOwned,
                    Value = addCollectionItemViewModel.Value,
                    Priority = addCollectionItemViewModel.Priority,
                    Condition = addCollectionItemViewModel.Condition,
                    Rarity = addCollectionItemViewModel.Rarity,
                    UserNote = addCollectionItemViewModel.UserNote,
                    CollectionID = addCollectionItemViewModel.CollectionID,
                };

                context.CollectionItems.Add(newItem);
                context.SaveChanges();
            }
            
        return RedirectToAction("DisplayCollection", "Collection", new {id = addCollectionItemViewModel.CollectionID});
    }

        public IActionResult EditCollectionItem(int id)
        {
            CollectionItem editCollectionItem = context.CollectionItems.Single(ci => ci.ID == id);

            ViewData["CollectionID"] = editCollectionItem.CollectionID;

            AddCollectionItemViewModel editCollectionItemViewModel = new AddCollectionItemViewModel();

            editCollectionItemViewModel.ItemName = editCollectionItem.ItemName;
            editCollectionItemViewModel.IsOwned = editCollectionItem.IsOwned;
            editCollectionItemViewModel.Value = editCollectionItem.Value;
            editCollectionItemViewModel.Priority = editCollectionItem.Priority;
            editCollectionItemViewModel.Condition = editCollectionItem.Condition;
            editCollectionItemViewModel.Rarity = editCollectionItem.Rarity;
            editCollectionItemViewModel.UserNote = editCollectionItem.UserNote;
            editCollectionItemViewModel.CollectionID = editCollectionItem.CollectionID;

            return View(editCollectionItemViewModel);
        }

        [HttpPost]
        public IActionResult EditCollectionItem(AddCollectionItemViewModel editCollectionItemViewModel, int id)
        {
            CollectionItem editCollectionItem = context.CollectionItems.Single(ci => ci.ID == id);

            if (ModelState.IsValid)
            {
                editCollectionItem.ItemName = editCollectionItemViewModel.ItemName;
                editCollectionItem.IsOwned = editCollectionItemViewModel.IsOwned;
                editCollectionItem.Value = editCollectionItemViewModel.Value;
                editCollectionItem.Priority = editCollectionItemViewModel.Priority;
                editCollectionItem.Condition = editCollectionItemViewModel.Condition;
                editCollectionItem.Rarity = editCollectionItemViewModel.Rarity;
                editCollectionItem.UserNote = editCollectionItemViewModel.UserNote;
                editCollectionItem.CollectionID = editCollectionItemViewModel.CollectionID;
            }
            context.Update(editCollectionItem);
            context.SaveChanges();

            return RedirectToAction("DisplayCollection", "Collection", new { id = editCollectionItem.CollectionID });
        }

        public IActionResult RemoveCollectionItem(int id)
        {
            CollectionItem theCollectionItem = context.CollectionItems.Single(ci => ci.ID == id);

            context.CollectionItems.Remove(theCollectionItem);
            context.SaveChanges();

            return RedirectToAction("DisplayCollection", "Collection", new { id = theCollectionItem.CollectionID });
        }
    }
}