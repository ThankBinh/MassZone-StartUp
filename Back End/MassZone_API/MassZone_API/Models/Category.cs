using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassZone_API.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cateId { get; set; }
        public string cateName { get; set; }
        public string cateImg { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Posts = new HashSet<Post>();
            this.Products = new HashSet<Product>();
        }
    }
}