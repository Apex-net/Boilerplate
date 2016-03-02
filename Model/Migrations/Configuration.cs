namespace Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model.DataAccessLayer;

    public sealed class Configuration : DbMigrationsConfiguration<Model.DataAccessLayer.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model.DataAccessLayer.SchoolContext context)
        {
            var generator = new SeedGenerator(context);
            generator.Generate();
        }
    }
}
