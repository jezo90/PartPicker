namespace PartPicker.Migrations
{
    using PartPicker.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<PartPicker.DAL.PickerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PartPicker.DAL.PickerContext";
        }

        protected override void Seed(PartPicker.DAL.PickerContext context)
        {
            PickerInitializer.SeedPickerData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
