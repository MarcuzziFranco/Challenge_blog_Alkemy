using Blog_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Blog_Challenge.Service;
using Blog_Challenge.ViewModels;

namespace Blog_Challenge.Controllers
{
    public class BlogPostController : Controller
    {
        TaskPost tasksPost;
        public BlogPostController()
        {
            //Encapsula las tareas del .c.r.u.d. en la bbdd.
            tasksPost = new TaskPost();
        }

        public ActionResult Home()
        {
            return View();
        }

        // GET: BlogPost
        [HttpGet]
        public ActionResult Home(string serchTittle)
        {
            
            Debug.WriteLine(serchTittle);
            if(serchTittle != null)
            {
                if (serchTittle.Length > 0)
                {
                    return View(tasksPost.SerchByTittle(serchTittle));
                }
            }
            return View();
        }



        [HttpGet]
        public ActionResult CreatePost()
        {
            Debug.WriteLine("GET Primer CreatePost");
            ViewBag.categorySelected = new SelectList(tasksPost.GetDataForCategoryList(), "Id", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost( PostViewModel postViewModel, HttpPostedFileBase imageFile) 
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.categorySelected = new SelectList(tasksPost.GetDataForCategoryList(), "Id", "Type");
                return View(postViewModel);  
            }
            else
            {
                if(imageFile != null)
                {
                    Debug.WriteLine("Guardamos Image.");
                    Debug.WriteLine("-----------------");
                    postViewModel.Id_image = tasksPost.SaveImageData(imageFile);
                    Debug.WriteLine("-----------------");
                    
                }
                else
                {
                    Debug.WriteLine("Sin imagen");
                }

                Debug.WriteLine(" POST Segundo Create post");              
                Debug.WriteLine(postViewModel.Tittle);
                Debug.WriteLine(postViewModel.Contain);
                Debug.WriteLine(postViewModel.Id_category);
                Debug.WriteLine(postViewModel.Id_image);
                Debug.WriteLine("----------------------------");
                postViewModel.Publication_date = DateTime.Now;
                Debug.WriteLine(postViewModel.Publication_date);
                Debug.WriteLine("----------------------------");
                tasksPost.SavePostData(postViewModel.toModel());
                return RedirectToAction("Home");
            }
        }
    }
}