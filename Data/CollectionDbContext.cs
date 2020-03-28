using CollectorDirector.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CollectorDirector.Data
{
    public class CollectionDbContext : DbContext
    {
        public DbSet<Collection> Collections { get; set; }
        //public DbSet<CollectionCategory> CollectionCategories { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<OwnedItem> OwnedItems { get; set; }
        public DbSet<UnownedItem> UnownedItems { get; set; }

        public CollectionDbContext(DbContextOptions<CollectionDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
