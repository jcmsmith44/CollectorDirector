using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectorDirector.Models
{
    public class CollectionItem
    {
        public string ItemName { get; set; }
        public int ID { get; set; }
        public bool IsOwned { get; set; }
        public string Rarity { get; set; }
        public string UserNote { get; set; }
        public int CollectionID { get; set; }
        //public int CategoryID { get; set; }
        //public CollectionCategory Category { get; set; }
    }
}
