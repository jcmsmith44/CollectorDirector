using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectorDirector.Models
{
    public class CollectionCategory
    {
        public string CategoryName { get; set; }
        public int ID { get; set; }
        public IList<CollectionItem> Items { get; set; }
    }
}
