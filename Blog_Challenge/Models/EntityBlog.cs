using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blog_Challenge.Models
{
    public class EntityBlog : DbContext
    {

        public EntityBlog() : base("name = Blog_DB")
        {
            //Modo de inicializacion de la base datos --> si no existe la crea.
            Database.SetInitializer(new CreateDatabaseIfNotExists<EntityBlog>());  
        }

        //Detallamos que clases del modelo sera posible hacerles querys de sql. 
        
        public DbSet<BlogPost> Blog_Posts { get; set; }
        
        public DbSet<Category> Blog_Category { get; set; }

        public DbSet<Image>    Blog_Image { get; set; }
       
    }
}