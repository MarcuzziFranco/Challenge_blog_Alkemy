using Blog_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;

namespace Blog_Challenge.Service
{
    public class TaskPost
    {
       
        public TaskPost()
        {

        }

        public IEnumerable<Models.Category> GetDataForCategoryList()
        {      
            using (EntityBlog db = new EntityBlog())
            {
                var result = from category in db.Blog_Category 
                                 select category;
                return result.ToList();             
            }
          
        }

        public List<BlogPost> SerchByTittle(string serchTittle)
        {                   
            using(EntityBlog db = new EntityBlog())
            {
                var result = from post in db.Blog_Posts
                             where post.Tittle.Contains(serchTittle)
                             select post;

                foreach(var item in result)
                {
                   Debug.WriteLine(item.Tittle);
                }
                  return result.ToList();
            }           
        }

        public void SavePostData(BlogPost post)
        {
            using(EntityBlog db = new EntityBlog())
            {
                Debug.WriteLine("Add post");
                db.Blog_Posts.Add(post);
                db.SaveChanges();               
            }
        }

        public int SaveImageData(HttpPostedFileBase imageFile)
        {
            int idImage;
            using(EntityBlog db = new EntityBlog())
            {
                Debug.WriteLine(imageFile.FileName);
                Debug.WriteLine(imageFile.ContentLength);

                 byte[] dataImage = new byte[imageFile.ContentLength];
                imageFile.InputStream.Read(dataImage, 0, imageFile.ContentLength);

                Image image = new Image();
                image.Name = imageFile.FileName;
                image.DataImage = dataImage;

                db.Blog_Image.Add(image);
                db.SaveChanges();

                idImage = db.Blog_Image.FirstOrDefault(img => img.Name == image.Name).Id;
                
            }

            return idImage;
        }

        public string LoadImage(int id)
        {
            string imgSrc="";
            
            using (EntityBlog db = new EntityBlog())
            {
                var dataImage = db.Blog_Image.FirstOrDefault(img => img.Id == id).DataImage;
                
                if(dataImage != null)
                {
                    var base64 = Convert.ToBase64String(dataImage);
                    imgSrc = string.Format("data:image/jpg;base{0}", base64);

                }
            }

            return imgSrc;
            
        }




    }
}