using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CavalloDelVentoWebApp.Models
{
    public partial class CavalloDelVentoWebAppModel : DbContext
    {
        public CavalloDelVentoWebAppModel()
            : base("name=CavalloDelVentoWebAppModel")
        {
        }
        public DbSet<Manager> managers { get; set; }
        public DbSet<ManagerRole> managerRoles { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
