namespace CavalloDelVentoWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CavalloDelVentoWebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CavalloDelVentoWebAppModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CavalloDelVentoWebAppModel context)
        {
            //context.managerRoles.AddOrUpdate(x => x.ID, new ManagerRole { ID = 1, roleName = "Admin", isDeleted = false });

            //context.managers.AddOrUpdate(x => x.ID, new Manager { ID = 1, subDealerName = "Gold Bike", mail = "goldbike@gmail.com", managerRole_ID = 1, password = "12345", isActive = true, isDeleted = false });
            //context.managers.AddOrUpdate(x => x.ID, new Manager { ID = 2, subDealerName = "Silver Bike", mail = "silverbike@gmail.com", managerRole_ID = 1, password = "123456", isActive = true, isDeleted = false });
            //context.managers.AddOrUpdate(x => x.ID, new Manager { ID = 3, subDealerName = "Bronze Bike", mail = "bronzebike@gmail.com", managerRole_ID = 1, password = "1234567", isActive = true, isDeleted = false });
            //context.managers.AddOrUpdate(x => x.ID, new Manager { ID = 4, subDealerName = "Normal Bike", mail = "normalbike@gmail.com", managerRole_ID = 1, password = "12345678", isActive = true, isDeleted = false });
        }
    }
}
