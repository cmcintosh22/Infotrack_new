using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infotrack.Models;
using Microsoft.EntityFrameworkCore;


namespace Infotrack.Data
{
    public class ScraperContext : DbContext
    {
        public ScraperContext(DbContextOptions<ScraperContext> options) : base(options)
        {
        }

        public DbSet<ScraperModel> ScraperData{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ScraperModel>().ToTable("ScraperData");
        }


    }
}
