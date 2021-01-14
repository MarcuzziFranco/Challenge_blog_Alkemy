namespace Blog_Challenge.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog_Challenge.Models.EntityBlog>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Blog_Challenge.Models.EntityBlog context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

          
           /* Models.Category BaseCategory = new Models.Category();
            BaseCategory.Type = "None";

            context.Blog_Category.Add(BaseCategory);
            context.SaveChanges(); */
        }
    }
}
