using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollectorDirector.ViewModels
{
    public class AddCollectionItemViewModel
    {
        [Required(ErrorMessage = "You must name your item")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "You must choose an owned status")]
        [Display(Name = "Do you own this item?")]
        public bool IsOwned { get; set; }

        [Required(ErrorMessage = "You must select a rarity")]
        [Display(Name = "How rare is this item?")]
        public string Rarity { get; set; }

        [Display(Name = "User note (optional)")]
        public string UserNote { get; set; }
        public int CollectionID { get; set; }
    }
}
