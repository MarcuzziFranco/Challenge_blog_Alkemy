using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog_Challenge.Models;

namespace Blog_Challenge.ViewModels
{
    public class PostViewModel
    {     
        public string Tittle { get; set; }
        public int Id_category { get; set; }
        public string Contain { get; set; }
        public int Id_image { get; set; }
        public DateTime Publication_date { get; set; }

        public BlogPost toModel()
        {
            BlogPost Post = new BlogPost();
            Post.Tittle = Tittle;
            Post.Id_category = Id_category;
            Post.Contain = Contain;
            Post.Id_image = Id_image;
            Post.Publication_Date = Publication_date;

            return Post;
        }

    }
}