using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassZone_API.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int proId { get; set; }
        public string proName { get; set; }
        public string proImg { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        
        public int? cateId { get; set; }
        [ForeignKey("cateId")]
        public virtual Category Categories { get; set; }
        public int? postId { get; set; }
        [ForeignKey("postId")]
        public virtual Post Posts { get; set; }



        public virtual ICollection<CheckOut> CheckOuts { get; set; }

        public Product()
        {
            this.CheckOuts = new HashSet<CheckOut>();
        }
    }
}