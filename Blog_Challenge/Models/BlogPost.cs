using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_Challenge.Models
{
    public class BlogPost
    {
        public int Id{ get; set; }

        [StringLength(200)]
        [Required(ErrorMessage ="Tittle is Required")]
        public string Tittle { get; set; }

        [Required(ErrorMessage ="Contains is Required")]
        public  int Id_category { get; set; }


        [Required(ErrorMessage = "Contains is Required")]
        public string Contain { get; set; }


        public int Id_image { get; set; }

        [Required]
        public DateTime Publication_Date { get; set; }
    }
}