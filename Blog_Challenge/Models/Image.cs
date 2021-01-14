﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Blog_Challenge.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set;}
        
        [Required]
        public byte[] DataImage { get; set; }
    }
}