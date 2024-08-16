using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KnowledgeHubPortal.Domain.Entities;
namespace KnowledgeHubPortal.Data
{
    public class KHPDbContext:DbContext
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
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KHPDb2024;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            }
        }

        public DbSet<Category> Categories { get; set; }
    }
}
