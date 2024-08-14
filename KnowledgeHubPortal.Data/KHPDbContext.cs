using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KnowledgeHubPortal.Domain.Entities;
namespace KnowledgeHubPortal.Data
{
    internal class KHPDbContext:DbContext
    {
        //Context file should not leave the DAL layer
        public KHPDbContext(DbContextOptions<KHPDbContext> options) : base(options)
        { }

        public KHPDbContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //If the client does not provide any options builder then only 
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");

            }
        }

        public DbSet<Category> Categories { get; set; }
    }
}
