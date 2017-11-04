using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassZone_API.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cmtId { get; set; }
        public string content { get; set; }

        
        public int? postId { get; set; }
        [ForeignKey("postId")]
        public virtual Post Posts { get; set; }
        public int? userId { get; set; }
        [ForeignKey("userId")]
        public virtual User Users { get; set; }
        public int? proId { get; set; }
        [ForeignKey("proId")]
        public virtual Product Products { get; set; }


        
    }
}